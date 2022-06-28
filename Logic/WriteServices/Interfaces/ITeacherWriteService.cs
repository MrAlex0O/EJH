using DataBase.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.WriteServices.Interfaces
{
    public interface ITeacherWriteService
    {
        public void Add(Guid personId);
        public Teacher Update(Guid Id);
        public Teacher Delete(Guid id);
    }
}
