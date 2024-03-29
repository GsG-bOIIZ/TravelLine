﻿using WebAppUniversity.Domain;
using WebAppUniversity.Dto;

namespace WebAppUniversity.Services
{
    public interface IStudentService
    {
        public List<Student> GetStudents();
        public int CreateStudent(StudentDto student);
        public void DeleteStudent(int studentId);
        public Student GetStudent(int studentId);
    }
}
