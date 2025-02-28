using System.ComponentModel.DataAnnotations;
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


    // Get route for Quadrants view
    [HttpGet]
    public IActionResult Quadrants()

    {
        var Quadrants = _context.Tasks
        return View(Quadrants);
    }

    // Get route to edit a task and populate fields in the already existing "TaskForm" view
    [HttpGet]
    public IActionResult Edit(int id)
    {
        var recordToEdit = _context.Tasks.Single(x => x.TaskId == id);
        ViewBag.Quadrants = _context.Quadrants.OrderBy(x => x.QuadrantName).ToList();

        return View("TaskForm", recordToEdit);

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
    public IActionResult ConfirmDeletion(int id)
    {
        var recordToDelete = _context.Tasks.Single(x => x.TaskId == id);
       
        return View(recordToDelete);
    }

    [HttpPost]
    public IActionResult Delete(Task task) 
    {
        _context.Tasks.Remove(task);
        _context.SaveChanges();

        return RedirectToAction("Quadrants");
    }


}

