﻿using AutoMapper;
using DataBase.Models;
using DataBase.Repositories.Interfaces;
using Logic.DTOs.LessonVisitor;
using Logic.WriteServices.Interfaces;

namespace Logic.WriteServices
{
    public class LessonVisitorWriteService : ILessonVisitorWriteService
    {
        private IUnitOfWorkRepository _repositories;
        readonly IMapper _mapper;
        public LessonVisitorWriteService(IUnitOfWorkRepository repositories, IMapper mapper)
        {
            _repositories = repositories;
            _mapper = mapper;
        }
        public void Add(CreateLessonVisitorRequest createlessonsVisitors)
        {
            LessonVisitor? lv = _repositories.LessonVisitors.GetAll()
                .Where(l => l.StudentId == createlessonsVisitors.StudentId && l.LessonId == createlessonsVisitors.LessonId)
                .FirstOrDefault();
            if (lv == null)
            {
                _repositories.LessonVisitors.Add(_mapper.Map<LessonVisitor>(createlessonsVisitors));
            }
            else
            {
                lv.StudentId = createlessonsVisitors.StudentId;
                lv.StatusOnLessonId = createlessonsVisitors.StatusOnLessonId;
                _repositories.LessonVisitors.Update(lv);
            }
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
