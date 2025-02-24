using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Mission08.Models;

namespace Mission08.Controllers;

public class HomeController : Controller
{
    private TaskDbContext _taskContext; // creates an instance of the database
    public HomeController(TaskDbContext temp)
    {
        _TaskContext = temp;
    }

    public IActionResult Index()
    {
        return View();
    }
    public IActionResult AddTask()
    {
        return View();
    }
    
    public IActionResult Confirmation()
    {
        return View();
    }


}