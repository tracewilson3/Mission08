using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Mission08.Models;
using Microsoft.EntityFrameworkCore;
using Task = Mission08.Models.Task;


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


    // Get route for Quadrants view
    [HttpGet]
    public IActionResult Quadrants()

    {
        var Quadrants = _context.Tasks;
        return View(Quadrants);
    }

    // Get route to edit a task and populate fields in the already existing "TaskForm" view

    [HttpGet]
    public IActionResult Add()
    {
        var task = new Task(); // Create a new Task object to avoid null reference issues
        ViewBag.Categories = _context.Categories.ToList();

        return View(task);
    }
    [HttpPost]
    public IActionResult Add(Task NewTask)
    {
        _context.Update(NewTask);
        _context.SaveChanges();

        return RedirectToAction("Quadrants");

    }
    [HttpGet]
    public IActionResult Edit(int id)
    {
        var recordToEdit = _context.Tasks.Single(x => x.TaskId == id);
        ViewBag.Quadrants = _context.Quadrants.OrderBy(x => x.QuadrantName).ToList();

        return View("Add", recordToEdit);

    }

    // Post route for the edit task functionality
    [HttpPost]
    public IActionResult Edit(Task updatedTask)
    {
        _context.Update(updatedTask);
        _context.SaveChanges();

        return RedirectToAction("Quadrants");

    }



    // Get route for deletion confirmation view
    [HttpGet]
    [HttpGet]
    public IActionResult ConfirmDeletion(int id)
    {
        var task = _context.Tasks.Find(id); // Fetch the existing task

        if (task == null)
        {
            return NotFound();
        }

        return View(task);
    }

    [HttpPost]
    public IActionResult ConfirmDeletion(Task task) 
    {
        var existingTask = _context.Tasks.Find(task.TaskId); // Ensure EF knows it's an existing record

        if (existingTask == null)
        {
            return NotFound();
        }

        _context.Tasks.Remove(existingTask); // Delete from database
        _context.SaveChanges();

        return RedirectToAction("Quadrants");
    }



}

