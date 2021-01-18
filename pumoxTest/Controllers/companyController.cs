using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using pumoxTest.Models;

namespace pumoxTest.Controllers
{
    public class companyController : ApiController
    {
      
        [HttpPost]
        // POST company/create
        public long Create(CompanyModel comp)
        {
            using (pumoxEntities ent = new pumoxEntities())
            {
                var c = new Company();
                c.Name = comp.Name;
                c.EstabilishmentYear = comp.EstabilishmentYear;
                comp.Employees = comp.Employees ?? new List<EmployeeModel>();
                foreach (var item in comp.Employees)
                {
                    var emp = new Employee();
                    emp.Company = c;
                    emp.Firstname = item.FirstName;
                    emp.Lastname = item.LastName;
                    emp.DateOfBirth = item.DateOfBirth;
                    emp.JobTitle = (int?)item.JobTitle;

                    ent.Employee.Add(emp);
                }
                ent.Company.Add(c);
                ent.SaveChanges();
                return c.Id;
            }
        }
        [HttpGet]
        public IEnumerable<Employee> Search([FromUri]SearchModel mod)
        {
            //SearchModel model = new SearchModel();
            //model.keyword = mod.keyword;
            //model.employeeDateOfBirthFrom = mod.employeeDateOfBirthFrom;
            //model.employeeDateOfBirthTo = mod.employeeDateOfBirthTo;
            //model.EmployeeJobTitles = mod.EmployeeJobTitles;
            return mod.Search(mod.keyword, mod.employeeDateOfBirthFrom, mod.employeeDateOfBirthTo, mod.EmployeeJobTitles);
        }



        [HttpPut]
        public void Update (int id, CompanyModel comp)
        {
            using (pumoxEntities ent = new pumoxEntities()) 
                {
                var c = ent.Company.Where(x => x.Id == id).SingleOrDefault();
                c.Name = comp.Name;
                c.EstabilishmentYear = comp.EstabilishmentYear;

                var query = ent.Employee.Where(x => x.CompanyId == id).ToList();
                foreach (var item in query)
                {
                    ent.Employee.Remove(item);
                }
            
                foreach (var item in comp.Employees)
                {
              
                    Employee emp = new Employee();

                    emp.Company = c;
                    emp.Firstname = item.FirstName;
                    emp.Lastname = item.LastName;
                    emp.DateOfBirth = item.DateOfBirth;
                    emp.JobTitle = (int?)item.JobTitle;

                    ent.Employee.Add(emp);
                }

                ent.SaveChanges();

            }

        }
        [HttpDelete]
        public void Delete (int id)
        {
            using (pumoxEntities ent = new pumoxEntities())
            {
                var employees = ent.Employee.Where(x => x.CompanyId == id);
                foreach (var item in employees)
                {
                    ent.Employee.Remove(item);
                }
                var company = ent.Company.SingleOrDefault(x=>x.Id == id);
                ent.Company.Remove(company);
            }
        }
    }
}
