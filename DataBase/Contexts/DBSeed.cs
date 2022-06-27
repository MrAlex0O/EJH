using DataBase.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBase.Contexts
{
    internal class SeedDB
    {
        private static void UpdateLessonType(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<LessonType>().HasData(new LessonType { 
                Id = Guid.Parse("6aa74582-0eba-4eee-a960-3b6fc3092130"), 
                Name = "Лекция", 
                EnumId = 1, 
                DateCreate = DateTime.Now,
                DateUpdate = DateTime.Now 
            });
            modelBuilder.Entity<LessonType>().HasData(new LessonType { 
                Id = Guid.Parse("3e46ecb0-a6e6-49eb-9f9e-32daa6595bc9"), 
                Name = "Лабораторная работа",
                EnumId = 2,
                DateCreate = DateTime.Now,
                DateUpdate = DateTime.Now
            });
            modelBuilder.Entity<LessonType>().HasData(new LessonType { 
                Id = Guid.Parse("f69a359a-4986-4253-9409-078660dc8fc8"), 
                Name = "Семинар", 
                EnumId = 3,
                DateCreate = DateTime.Now,
                DateUpdate = DateTime.Now
            });
            //modelBuilder.Entity<LessonType>().HasData(new LessonType { Id = Guid.Parse("bc9474a1-4fb2-4638-b1c4-f4ca21c68bb9"), Name = "" });
            //modelBuilder.Entity<LessonType>().HasData(new LessonType { Id = Guid.Parse("79765635-f6e4-49bf-a7ac-11c3458f2fa9"), Name = "" });

        }
        private static void UpdateStatusOnLesson(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<StatusOnLesson>().HasData(new StatusOnLesson { 
                Id = Guid.Parse("6aa74582-0eba-4eee-a960-3b6fc3092130"), 
                Name = "Присутствовал",
                EnumId = 1,
                DateCreate = DateTime.Now,
                DateUpdate = DateTime.Now
            });
            modelBuilder.Entity<StatusOnLesson>().HasData(new StatusOnLesson { 
                Id = Guid.Parse("3e46ecb0-a6e6-49eb-9f9e-32daa6595bc9"), 
                Name = "Отсутствовал", 
                EnumId = 2,
                DateCreate = DateTime.Now,
                DateUpdate = DateTime.Now
            });
            modelBuilder.Entity<StatusOnLesson>().HasData(new StatusOnLesson { 
                Id = Guid.Parse("f69a359a-4986-4253-9409-078660dc8fc8"), 
                Name = "Освобожден", 
                EnumId = 3,
                DateCreate = DateTime.Now,
                DateUpdate = DateTime.Now
            });
            modelBuilder.Entity<StatusOnLesson>().HasData(new StatusOnLesson { 
                Id = Guid.Parse("bc9474a1-4fb2-4638-b1c4-f4ca21c68bb9"), 
                Name = "Другая подгруппа", 
                EnumId = 4,
                DateCreate = DateTime.Now,
                DateUpdate = DateTime.Now
            });
            //modelBuilder.Entity<LessonType>().HasData(new LessonType { Id = Guid.Parse("79765635-f6e4-49bf-a7ac-11c3458f2fa9"), Name = "" });
        }
        public static void UpdateTables(ModelBuilder modelBuilder)
        {
            UpdateLessonType(modelBuilder);
            UpdateStatusOnLesson(modelBuilder);

        }
    }
}
