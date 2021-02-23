using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TechJobsPersistent.Data;
using TechJobsPersistent.Models;
using TechJobsPersistent.ViewModels;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TechJobsPersistent.Controllers
{
    public class EmployerController : Controller
    {
        private JobDbContext context;

        public EmployerController (JobDbContext dbContext)
        {
            context = dbContext;
        }

        public IActionResult Index()
        {
            List<Employer> employers = context.Employers.ToList();
            return View(employers);
        }

        public IActionResult Add()
        {
            AddEmployerViewModel addEVM = new AddEmployerViewModel();
            return View(addEVM);
        }

        public IActionResult ProcessAddEmployerForm(AddEmployerViewModel addEVM)
        {
            if (ModelState.IsValid)
            {
                Employer employerObj = new Employer
                {
                    Name = addEVM.Name,
                    Location = addEVM.Location
                };

                context.Employers.Add(employerObj);
                context.SaveChanges();
                return Redirect("Employer");
            }
            return View("Add", addEVM);
        }

        public IActionResult About(int id)
        {
            Employer employer = context.Employers.Find(id);
            return View(employer);
        }
    }
}
