using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.Extensions.Logging;
using MVCApp.Models;
using MVCApp.Services;

namespace MVCApp.Controllers
{
    
    public class StudentController : Controller
    {
        private readonly StudentService _StudentService;

        public StudentController(StudentService studentservice)
        {
            _StudentService = studentservice;
        }

        public async Task<IActionResult> Index()
        {
            var students = await _StudentService.GetAllAsync();
            return View(students);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Student student)
        {
            if (ModelState.IsValid)
            {
                await _StudentService.AddAsync(student);
                return RedirectToAction("Index");
            }
            return View(student);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var student = await _StudentService.GetByIdAsync(id);
            if (student == null)
            {
                return NotFound();
            }
            return View(student);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Student student)
        {
            if (ModelState.IsValid)
            {
                await _StudentService.UpdateAsync(student);
                return RedirectToAction("Index");
            }
            return View(student);
        }
        

        public async Task<IActionResult> Delete(int id)
        {
            var student = await _StudentService.GetByIdAsync(id);
            if (student == null)
            {
                return NotFound();
            }
            return View(student);
        }

        [HttpPost,ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirm(int id)
        {
            
            await _StudentService.DeleteAsync(id);
            return RedirectToAction("Index");
            
            
        }

       
    }
}