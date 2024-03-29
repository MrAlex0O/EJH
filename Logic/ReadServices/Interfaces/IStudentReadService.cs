﻿using Logic.DTOs.Student;

namespace Logic.ReadServices.Interfaces
{
    public interface IStudentReadService
    {
        public Task<IEnumerable<GetStudentResponse>> GetAll();
        public Task<GetStudentResponse> Get(Guid id);
        public Task<IEnumerable<GetStudentResponse>> GetByGroupId(Guid groupIdd);
    }
}
