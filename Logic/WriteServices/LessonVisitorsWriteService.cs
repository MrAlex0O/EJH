using AutoMapper;
using DataBase.Models;
using DataBase.Repositories.Interfaces;
using Logic.DTOs.LessonVisitors;
using Logic.WriteServices.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.WriteServices
{
    public class LessonVisitorsWriteService : ILessonVisitorWriteService
    {
        private IUnitOfWorkRepository _repositories;
        readonly IMapper _mapper;
        public LessonVisitorsWriteService(IUnitOfWorkRepository repositories, IMapper mapper)
        {
            _repositories = repositories;
            _mapper = mapper;
        }
        public void Add(CreateLessonVisitorRequest createlessonsVisitors)
        {
            _repositories.LessonVisitors.Add(_mapper.Map<LessonVisitor>(createlessonsVisitors));
            _repositories.SaveChanges();
        }

        public void Delete(Guid id)
        {
            LessonVisitor lessonsVisitor = _repositories.LessonVisitors.Get(id);
            _repositories.LessonVisitors.Delete(lessonsVisitor);
            _repositories.SaveChanges();
        }

        public void Update(Guid id, UpdateLessonVisitorRequest updatelessonsVisitors)
        {
            LessonVisitor lessonsVisitor = _repositories.LessonVisitors.Get(id);

            _mapper.Map<UpdateLessonVisitorRequest, LessonVisitor>(updatelessonsVisitors, lessonsVisitor);
            _repositories.LessonVisitors.Update(lessonsVisitor);
            _repositories.SaveChanges();
        }
    }
}
