namespace MarialaTemplate.Areas.MarialaAdmin.ViewModels
{
    public class UpdateEmployeeVM
    {
        public string Name { get; set; }
        public string Profession { get; set; }
        public string Image { get; set; }
        public IFormFile? Photo { get; set; }
    }
}
