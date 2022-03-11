using AspnetWebApi_curd.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace AspnetWebApi_curd.Controllers
{
    public class CurdApiController : ApiController
    {
        readonly MydbEntities db = new MydbEntities();

        [HttpGet]
        public IHttpActionResult GetEmployees()
        {
            List<employee> list= db.employees.ToList();
            return Ok(list);
        }
        [HttpGet]
        public IHttpActionResult GetEmployeeById(int id)
        {
            var emp = db.employees.Where(model => model.id == id).FirstOrDefault();
            return Ok(emp);
        }

        [HttpPost]
        public IHttpActionResult InsertEmp(employee e)
        {
            db.employees.Add(e);
            db.SaveChanges();
            return Ok();
        }
        [System.Web.Http.HttpPut]
        public IHttpActionResult UpdateEmp(employee e)
        {


            //db.Entry(e).State = System.Data.Entity.EntityState.Modified;
            //db.SaveChanges();
            var emp = db.employees.Where(model => model.id == e.id).FirstOrDefault();
            if (emp != null)
            {
                emp.id = e.id;
                emp.name = e.name;
                emp.gender = e.gender;
                emp.age = e.age;
                emp.designation = e.designation;
                emp.salary = e.salary;
                db.SaveChanges();
            }
            else
            {
                return NotFound();
            }

           return Ok();
        }
        [HttpDelete]
        public IHttpActionResult DeleteEmp(int id)
        {
            var emp = db.employees.Where(model => model.id == id).FirstOrDefault();
            db.Entry(emp).State = System.Data.Entity.EntityState.Deleted;
            db.SaveChanges();
            return Ok();
        }


    }
}
