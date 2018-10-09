using BAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web.Models
{
    public class CompanyViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<string> Categories { get; set; }

        public static CompanyViewModel Init(Company company, List<Category> categories)
        {
            return new CompanyViewModel()
            {
                Id = company.Id,
                Name = company.Name,
                Categories = categories.Select(x => x.Name).ToList()
            };
        }
    }
}