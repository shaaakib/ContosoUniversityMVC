﻿using ContosoUniversity.Data;
using ContosoUniversity.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ContosoUniversity.Controllers
{
    public class StudentsController : Controller
    {
        private readonly SchoolContext _context;

        public StudentsController(SchoolContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index( string sortOrder,string currentFilter, string searchString,
        int? pageNumber)
        {
            ViewData["CurrentSort"] = sortOrder;
            ViewData["NameSortParm"] = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewData["DateSortParm"] = sortOrder == "Date" ? "date_desc" : "Date";
            ViewData["CurrentFilter"] = searchString;
            var students = from s in _context.Students select s;

            if (searchString != null)
            {
                pageNumber = 1;
            }
            else
            {
                searchString = currentFilter;
            }
            
            if (!String.IsNullOrEmpty(searchString))
            {
                students = students.Where(s => s.Name.Contains(searchString));
            }
            switch (sortOrder)
            {
                case "name_desc":
                    students = students.OrderByDescending(s => s.Name);
                    break;
                case "Date":
                    students = students.OrderBy(s => s.EnrollmentDate);
                    break;
                default:
                    students = students.OrderBy(s => s.Name);
                    break;
            }

            int pageSize = 3;
            return View(await PaginatedList<Student>.CreateAsync(students.AsNoTracking(), pageNumber ?? 1, pageSize));
        }

        public async Task<IActionResult> Details(int?id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var student = await _context.Students.Include(p => p.Enrollments).ThenInclude(t => t.Course)
                .FirstOrDefaultAsync(m => m.ID == id);


            if (student == null) {
                return NotFound();
            }
            return View(student);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name,EnrollmentDate")] Student student)
        {
            if (ModelState.IsValid)
            {
                _context.Students.Add(student);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index","Students");
            }
            return View(student);
        }

        public async Task<IActionResult> Edit(int? id) 
        {

            var student = await _context.Students.FindAsync(id);

            return View(student);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(int id, [Bind("ID,EnrollmentDate,Name")] Student student)
        {
            if (ModelState.IsValid)
            {
                _context.Students.Update(student);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index", "Students");
            }
            return View(student);
        } 
        //public async Task<IActionResult> Delete(int? id) 
        //{

        //    var student = await _context.Students.FindAsync(id);

        //    if (student == null) {
        //        return NotFound();
        //    }

        //    return View(student);
        //}
        //[HttpPost, ActionName("Delete")]
        public async Task<IActionResult> Delete(int id)
        {
            var std = await _context.Students.FindAsync(id);
                _context.Students.Remove(std);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index", "Students");
            
        }

    }
}
