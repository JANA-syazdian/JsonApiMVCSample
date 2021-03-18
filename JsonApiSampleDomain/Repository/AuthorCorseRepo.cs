using JsonApiSampleDomain.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace JsonApiSampleDomain.Repository
{
    public class AuthorCorseRepo
    {

       static List<Course> courses1 = new List<Course>()
            {
                new Course(){Id = 1, Title = "Physics"},
                new Course(){Id = 2, Title = "Math"},
            
            };

        static List<Course> courses2 = new List<Course>()
            {
               new Course() { Id = 3, Title = "English"},
                new Course() { Id = 4, Title = "Sport"}
            };
      
        static List<Author> authors = new List<Author>()
            {
                new Author(){Id = 1, Name="Sharif", Courses=courses1},
                new Author(){Id = 2, Name="Moeen", Courses=courses2},
              
            };




        public List<Course> GetCourses1()
        {
                      return courses1;
        }

        public List<Author> GetAuthors()
        {
            return authors;
        }


    }

}
