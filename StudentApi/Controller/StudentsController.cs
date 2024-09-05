using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudentApi.Data;
using StudentApi.Models;

namespace StudentApi.Controller
{
    [ApiController]
    [Route("api/[controller]")]
    public class StudentsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public StudentsController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IEnumerable<Student>> GetStudents()
        {
            var students = await _context.Students.AsNoTracking().ToListAsync();

            return students;
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Student>> GetStudent(int id)
        {
            var student = await _context.Students.FindAsync(id);

            if (student is null) return NotFound();

            return Ok(student);
        }

        [HttpPost]
        public async Task<IActionResult> Create(Student student)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _context.AddAsync(student);

            var result = await _context.SaveChangesAsync();

            if (result > 0) return Ok();

            return BadRequest();
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> EditStudent(int id, Student newStudent)
        {
            var oldStudent = await _context.Students.FindAsync(id);

            if (oldStudent is null) return NotFound($"Student with id {id} was not found");

            oldStudent.Name = newStudent.Name;
            oldStudent.Address = newStudent.Address;
            oldStudent.Email = newStudent.Email;
            oldStudent.PhoneNumber = newStudent.PhoneNumber;

            var result = await _context.SaveChangesAsync();

            if (result > 0) return Ok("The student was sucessfully updated");

            return BadRequest("Unable to update the student");
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<Student>> Delete(int id)
        {
            var student = await _context.Students.FindAsync(id);

            if (student is null) return NotFound();

            _context.Remove(student);

            var result = await _context.SaveChangesAsync();

            if (result > 0) return Ok("Student deleted");

            return BadRequest($"Unable to delete the student with id: {id}");
        }
    }
}