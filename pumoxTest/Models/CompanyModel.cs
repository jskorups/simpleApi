using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace pumoxTest.Models
{
   
        public class CompanyModel
        {
        //comment
            public string Name { get; set; }
            public int EstabilishmentYear { get; set; }
            public IEnumerable<EmployeeModel> Employees { get; set; }

        }
    
}