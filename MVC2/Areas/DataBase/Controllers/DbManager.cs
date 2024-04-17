using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVC2.Models;

namespace MVC2.Areas.DataBase.Controllers
{
	[Area("DataBase")]
	[Route("/database-manage/[action]")]
	public class DbManager : Controller
	{
		private readonly AppDbContext _context;

		public DbManager(AppDbContext context)
		{
			_context = context;
		}

		public IActionResult Index()
		{
			return View();
		}
		[HttpGet]
		public IActionResult DeleteDb()
		{
			return View();
		}
		[HttpPost]
		public async Task<IActionResult> DeleteDbAsync() {
			var success = await _context.Database.EnsureDeletedAsync();
			return RedirectToAction("Index");
		}
		[HttpPost]
		public async Task<IActionResult> UpdateDb()
		{
			await _context.Database.MigrateAsync();
			return RedirectToAction("Index");
		}
	}
}
