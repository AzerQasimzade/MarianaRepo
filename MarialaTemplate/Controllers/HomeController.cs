using MarialaTemplate.DAL;
using MarialaTemplate.Models;
using MarialaTemplate.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace MarialaTemplate.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppDbContext _context;

        public HomeController(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            List<Employee> employees = await _context.Employees.ToListAsync();
            List<Project> projects = await _context.Projects.ToListAsync();
            List<Service> services = await _context.Services.ToListAsync();
            HomeVM homeVM = new HomeVM
            {
                Employees = employees,
                Projects = projects,
                Services = services
            };
            return View(homeVM);

        }
    }
}
