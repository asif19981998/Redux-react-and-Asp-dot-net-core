using Login_and_Log_out.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Login_and_Log_out.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        List<Student> students = new List<Student>()
           {
               new Student(){Id=1,Name="Asif Islam",Age=25},
               new Student(){Id=2,Name="Tamim Islam",Age=35},
               new Student(){Id=3,Name="Amin Islam",Age=35},
               new Student(){Id=4,Name="Naxor Islam",Age=45},
               new Student(){Id=5,Name="Rafiq Islam",Age=35},
               new Student(){Id=6,Name="Junaid Islam",Age=50}
           };
        // GET: api/<StudentController>
        [HttpGet]
        public ICollection<Student> Get()
        {
         
            return students;
        }

        // GET api/<StudentController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<StudentController>
        [HttpPost]
        public ICollection<Student> Post(Student model)
        {
            students.Add(model);
            return students;
        }

        // PUT api/<StudentController>/5
        [HttpPut("{id}")]
        public ICollection<Student> Put(Student model)
        {
            var index = students.FindIndex(stu => stu.Id == model.Id);
            students.RemoveAt(index);
            students.Insert(index, model);
            return students;
        }

        // DELETE api/<StudentController>/5
        [HttpDelete("{id}")]
        public ICollection<Student> Delete(int id)
        {
           var student =  students.Find(stu => stu.Id == id);
            students.Remove(student);
            return students;
        }
    }
}
