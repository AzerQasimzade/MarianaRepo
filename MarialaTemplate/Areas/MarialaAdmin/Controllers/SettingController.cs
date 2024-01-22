using MarialaTemplate.Areas.MarialaAdmin.ViewModels;
using MarialaTemplate.DAL;
using MarialaTemplate.Models;
using MarialaTemplate.Utilities.Enums;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MarialaTemplate.Areas.MarialaAdmin.Controllers
{
    [Area("MarialaAdmin")]
    public class SettingController : Controller
    {
        private readonly AppDbContext _context;

        public SettingController(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            List<Setting> list = await _context.Settings.ToListAsync();
            return View(list);
        }
        public async Task<IActionResult> Update(int id)
        {
            if (id <= 0)
            {
                return BadRequest();
            }
            Setting existed = await _context.Settings.FirstOrDefaultAsync(x => x.Id == id);
            if (existed == null)
            {
                return NotFound();
            }
            UpdateSettingVM settingVM = new UpdateSettingVM
            {
                Value = existed.Value,
            };
            return View(settingVM);
        }
        [HttpPost]
        public async Task<IActionResult> Update(int id,UpdateSettingVM settingVM)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            Setting existed= await _context.Settings.FirstOrDefaultAsync(y => y.Id == id);
            existed.Value= settingVM.Value;
            await _context.SaveChangesAsync();
            return RedirectToAction("Index", "Home");
        }
        public async Task<IActionResult> Delete(int id)
        {
            if (id <= 0)
            {
                return BadRequest();
            }
            Setting existed = await _context.Settings.FirstOrDefaultAsync(x => x.Id == id);
            if (existed == null)
            {
                return NotFound();
            }
            _context.Settings.Remove(existed);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index", "Home");

        }
    }
}
