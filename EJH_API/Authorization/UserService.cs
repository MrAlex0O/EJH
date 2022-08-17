using API.Authorization.Models;
using AutoMapper;
using DataBase.Contexts;
using DataBase.Models;
using Org.BouncyCastle.Crypto.Generators;
using BCrypt.Net;

namespace API.Authorization
{
    public class UserService : IUserService
    {
        private Context _context;
        private IJwtUtils _jwtUtils;
        private readonly IMapper _mapper;

        public UserService(Context context, IJwtUtils jwtUtils, IMapper mapper)
        {
            _context = context;
            _jwtUtils = jwtUtils;
            _mapper = mapper;
        }

        public AuthResponse Authenticate(AuthRequest model)
        {
            var user = _context.Users.FirstOrDefault(x => x.Username == model.Username);

            // validate
            if (user == null || !BCrypt.Net.BCrypt.Verify(model.Password, user.PasswordHash))
                throw new Exception("Username or password is incorrect");

            // authentication successful
            AuthResponse response = _mapper.Map<AuthResponse>(user);
            Person person = _context.Persons.Where(i => i.Id == user.PersonId).FirstOrDefault();
            response.Surname = person.Surname;
            response.Name = person.Name;
            response.Token = _jwtUtils.GenerateToken(user);
            return response;
        }
        public IEnumerable<User> GetAll()
        {
            return _context.Users;
        }

        public User GetById(Guid id)
        {
            return getUser(id);
        }

        public bool Register(RegisterRequest model)
        {
            // validate
            if (_context.Users.Any(x => x.Username == model.Username))
                return false;

            // map model to new user object
            var user = _mapper.Map<User>(model);
            var person = _mapper.Map<Person>(model);
            // hash password
            user.PasswordHash = BCrypt.Net.BCrypt.HashPassword(model.Password);

            // save user
            person = _context.Persons.Add(person).Entity;
            user.PersonId = person.Id;
            _context.Users.Add(user);
            _context.SaveChanges();
            return true;
        }
        

        public void Update(Guid id, UpdateRequest model)
        {
            var user = getUser(id);

            // validate
            if (model.Username != user.Username && _context.Users.Any(x => x.Username == model.Username))
                throw new Exception("Username '" + model.Username + "' is already taken");

            // hash password if it was entered
            if (!string.IsNullOrEmpty(model.Password))
                user.PasswordHash = BCrypt.Net.BCrypt.HashPassword(model.Password);

            // copy model to user and save
            _mapper.Map(model, user);
            _context.Users.Update(user);
            _context.SaveChanges();
        }

        public void Delete(Guid id)
        {
            var user = getUser(id);
            _context.Users.Remove(user);
            _context.SaveChanges();
        }

        // helper methods

        private User getUser(Guid id)
        {
            var user = _context.Users.Find(id);
            if (user == null) throw new KeyNotFoundException("User not found");
            return user;
        }

    }
}
