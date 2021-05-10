using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using QuizLogic.Models;
using QuizLogicView.Data;

namespace QuizLogicView.Controllers
{
    public class StudentQuestionsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public StudentQuestionsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: StudentQuestions
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.StudentQuestions.Include(s => s.StudentResponse).Include(i => i.StudentAnswers);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: StudentQuestions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var studentQuestion = await _context.StudentQuestions
                .Include(s => s.StudentResponse).Include(i => i.StudentAnswers)
                .FirstOrDefaultAsync(m => m.StudentQuestionId == id);
            if (studentQuestion == null)
            {
                return NotFound();
            }

            return View(studentQuestion);
        }

        // GET: StudentQuestions/Create
        public IActionResult Create()
        {
            ViewData["StudentResponseId"] = new SelectList(_context.StudentResponses, "StudentResponseId", "StudentResponseId");
            return View();
        }

        // POST: StudentQuestions/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("StudentQuestionId,StudentResponseId,StudentId,QuestionNumber,Question,QuestionHint,QuestionTypeName")] StudentQuestion studentQuestion)
        {
            if (ModelState.IsValid)
            {
                _context.Add(studentQuestion);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["StudentResponseId"] = new SelectList(_context.StudentResponses, "StudentResponseId", "StudentResponseId", studentQuestion.StudentResponseId);
            return View(studentQuestion);
        }

        // GET: StudentQuestions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var studentQuestion = await _context.StudentQuestions.FindAsync(id);
            if (studentQuestion == null)
            {
                return NotFound();
            }
            ViewData["StudentResponseId"] = new SelectList(_context.StudentResponses, "StudentResponseId", "StudentResponseId", studentQuestion.StudentResponseId);
            return View(studentQuestion);
        }

        // POST: StudentQuestions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("StudentQuestionId,StudentResponseId,StudentId,QuestionNumber,Question,QuestionHint,QuestionTypeName")] StudentQuestion studentQuestion)
        {
            if (id != studentQuestion.StudentQuestionId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(studentQuestion);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StudentQuestionExists(studentQuestion.StudentQuestionId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["StudentResponseId"] = new SelectList(_context.StudentResponses, "StudentResponseId", "StudentResponseId", studentQuestion.StudentResponseId);
            return View(studentQuestion);
        }

        // GET: StudentQuestions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var studentQuestion = await _context.StudentQuestions
                .Include(s => s.StudentResponse)
                .FirstOrDefaultAsync(m => m.StudentQuestionId == id);
            if (studentQuestion == null)
            {
                return NotFound();
            }

            return View(studentQuestion);
        }

        // POST: StudentQuestions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var studentQuestion = await _context.StudentQuestions.FindAsync(id);
            _context.StudentQuestions.Remove(studentQuestion);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StudentQuestionExists(int id)
        {
            return _context.StudentQuestions.Any(e => e.StudentQuestionId == id);
        }
    }
}
