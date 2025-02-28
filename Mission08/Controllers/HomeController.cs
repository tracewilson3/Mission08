using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Mission08.Models;
using Microsoft.EntityFrameworkCore;


namespace Mission08.Controllers;

public class HomeController : Controller
{
    private FTFDbContext _context;

    public HomeController(FTFDbContext context)
    {
        _context = context;
    }

    public IActionResult Index()
    {
        var FTF = _context.Tasks
            .Include(t => t.Quadrant) // Include Quadrant data
            .Include(t => t.Category);
        return View(FTF);
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
