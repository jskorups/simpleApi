using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace pumoxTest.Models
{
    public class SearchModel
    {
        public string keyword { get; set; }
        public DateTime? employeeDateOfBirthFrom { get; set; }
        public DateTime? employeeDateOfBirthTo { get; set; }
        public JobTitles EmployeeJobTitles { get; set; }


        private static IQueryable<Employee> FilterByKeword(IQueryable<Employee> employees, string keyword)
        {
            if (keyword == null)
            {
                return employees;
            }
            else
            {
                return employees.Where(x => (x.Firstname.Contains(keyword) || x.Lastname.Contains(keyword) || x.Company.Name.Contains(keyword)));
            }
        }
        private static IQueryable<Employee> FilterByDate(IQueryable<Employee> employees, DateTime? from, DateTime? to)
        {

            if (from.HasValue && to.HasValue)
            {
                return employees.Where(x => x.DateOfBirth >= from.Value && x.DateOfBirth <= to.Value);
            }
            else if (from.HasValue)
            {
                return employees.Where(x => x.DateOfBirth >= from);
            }
            else if (to.HasValue)
            {
                return employees.Where(x => x.DateOfBirth <= to);
            }
            return employees;
        }

        private static IQueryable<Employee> FilterByJobTitle(IQueryable<Employee> employees, JobTitles? jobTitle)
        {

            if (jobTitle == null)
                return employees;

            return employees.Where(e => e.JobTitle == (int?)jobTitle);

        }



        public IEnumerable<Employee> Search(string keyword, DateTime? employeeDateOfBirthFrom, DateTime? employeeDateOfBirthTo, JobTitles employeeJobTitles)
        {

            pumoxEntities ent = new pumoxEntities();
            ent.Configuration.ProxyCreationEnabled = false;
            var res = FilterByKeword(ent.Employee, keyword);
            res = FilterByDate(res, employeeDateOfBirthFrom, employeeDateOfBirthTo);
            res = FilterByJobTitle(res, employeeJobTitles);



            //var result = res.GroupBy(x => new { x.Company.Name, x.Company.EstabilishmentYear }).ToList();

            //return result;
            return res;
        }

    }
}