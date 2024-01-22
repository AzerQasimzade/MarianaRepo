using MarialaTemplate.Models;

namespace MarialaTemplate.ViewModels
{
    public class HomeVM
    {
        public List<Employee> Employees { get; set; }
        public List<Project> Projects { get; set; }
        public List<Service> Services { get; set; }
    }
}
