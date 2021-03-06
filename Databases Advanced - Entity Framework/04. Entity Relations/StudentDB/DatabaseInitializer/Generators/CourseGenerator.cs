﻿namespace DatabaseInitializer.Generators
{
    using P01_StudentSystem.Data;
    using P01_StudentSystem.Data.Models;
    using System;

    public class CourseGenerator
    {
        private static Random rnd = new Random();

        private static string[] courseNames =
        {
            "Programming Basics",
            "Programming Fundamentals",
            "C# Fundamentals",
            "Java Fundamentals",
            "C# DB Basics",
            "C# DB Advanced"
        };

        internal static void InitialCourseSeed(StudentSystemContext db, int count)
        {
            for (int i = 0; i < count; i++)
            {
                db.Courses.Add(NewCourse());
                db.SaveChanges();
            }
        }

        private static Course NewCourse()
        {
            DateTime startDate = DateGenerator.GenerateDate();

            Course course = new Course()
            {
                Name = GenerateCourseName(),
                StartDate = startDate,
                EndDate = DateGenerator.GenerateEndDate(startDate),
                Price = NewPrice()
            };

            return course;
        }

        private static decimal NewPrice()
        {
            var price = rnd.NextDouble() * 600;

            return Convert.ToDecimal(price);
        }

        public static string GenerateCourseName()
        {
            return courseNames[rnd.Next(0, courseNames.Length)];
        }
    }
}