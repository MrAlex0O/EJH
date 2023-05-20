﻿namespace Logic.DTOs.Teacher
{
    public class GetTeacherResponse
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string? Midname { get; set; }
        public string Surname { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
    }
}
