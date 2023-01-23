using Logic.ReadServices.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataBase.Enums;
using DataBase.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Logic.ReadServices
{
    public class ReportReadService : IReportReadService
    {
        private IUnitOfWorkRepository _unitOfWorkRepository;

        public ReportReadService(IUnitOfWorkRepository unitOfWorkRepository)
        {
            _unitOfWorkRepository = unitOfWorkRepository;
        }

        public List<object> GigaFunction(Guid lessonId)
        {
            var queryable = _unitOfWorkRepository.Lessons.Where(x => x.Id == lessonId).Include(l => l.LessonVisitors)
                .ThenInclude(lv => lv.Student).ThenInclude(s => s.Person).Include(l => l.LessonVisitors)
                .ThenInclude(sl => sl.StatusOnLesson).Select(rl => (object) new
                {
                    name = rl.LessonVisitors.FirstOrDefault().Student.Person.Surname,
                    sLess1 = rl.LessonVisitors.FirstOrDefault(lv =>
                        lv.StatusOnLesson != null && lv.StatusOnLesson.EnumId == (int)StatusOnLessonEnum.Present),
                    sLess2 = rl.LessonVisitors.FirstOrDefault(lv =>
                        lv.StatusOnLesson != null && lv.StatusOnLesson.EnumId == (int)StatusOnLessonEnum.Missing)
                });
            
            return queryable.ToList();
        }
    }
}