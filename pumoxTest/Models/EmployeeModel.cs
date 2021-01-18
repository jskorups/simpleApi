using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace pumoxTest.Models
{
    public class EmployeeModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public JobTitles JobTitle { get; set; }
        //public long CompanyId { get; set; }


    
    }

    public enum JobTitles
    {
        Administrator,
        Developer,
        Architect,
        Manager
    }




}