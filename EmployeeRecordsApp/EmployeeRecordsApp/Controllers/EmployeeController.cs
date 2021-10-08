using EmployeeRecordsApp.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeRecordsApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EmployeeController : ControllerBase
    {
        EmployeeRecordDbContext db;
        public EmployeeController(EmployeeRecordDbContext db)
        {
            this.db = db;
        }
        [HttpGet]
        public Employee GetEmployee(int id)
        {
            return db.Employee.FirstOrDefault(x=>x.Id == id);
        }
        [HttpPost]
        public Employee PostEmployee(Employee employee)
        {
            db.Employee.Add(employee);
            db.SaveChanges(); 
            return employee;
        }
        [HttpDelete]
        public Employee DeleteEmployee(int id)
        {
            Employee employee = db.Employee.FirstOrDefault(x => x.Id == id);
            if(employee != null)
            {
                db.Employee.Remove(employee);
                db.SaveChanges();
            }
            return employee;
        }
        [HttpPut]
        public Employee PutEmployee(int id,Employee employee)
        {
            Employee exisEmployee =  db.Employee.FirstOrDefault(x => x.Id == id);
            if (exisEmployee == null)
                return null;

            exisEmployee.FirstName = employee.FirstName;
            exisEmployee.MiddleName = employee.MiddleName;
            exisEmployee.LastName = employee.LastName;
            db.Employee.Update(exisEmployee);
            db.SaveChanges();
            return exisEmployee;
        }
    }
}
