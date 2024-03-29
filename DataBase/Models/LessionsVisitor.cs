﻿namespace DataBase.Models
{
    public class LessonVisitor : BaseModel
    {
        public Guid? LessonId { get; set; }
        public Lesson? Lesson { get; set; }
        public Guid? StudentId { get; set; }
        public Student? Student { get; set; }
        public Guid? StatusOnLessonId { get; set; }
        public StatusOnLesson? StatusOnLesson { get; set; }
    }
}
