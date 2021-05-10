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
    public class QuestionOptionsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public QuestionOptionsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: QuestionOptions
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.QuestionOptions.Include(q => q.Question);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: QuestionOptions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var questionOption = await _context.QuestionOptions
                .Include(q => q.Question)
                .FirstOrDefaultAsync(m => m.QuestionOptionId == id);
            if (questionOption == null)
            {
                return NotFound();
            }

            return View(questionOption);
        }

        // GET: QuestionOptions/Create
        public IActionResult Create()
        {
            ViewData["QuestionId"] = new SelectList(_context.Questions, "QuestionId", "QuestionName");
            return View();
        }

        // POST: QuestionOptions/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("QuestionOptionId,QuestionId,OptionValue,IsCorrect")] QuestionOption questionOption)
        {
            if (ModelState.IsValid)
            {
                _context.Add(questionOption);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["QuestionId"] = new SelectList(_context.Questions, "QuestionId", "QuestionName", questionOption.QuestionId);
            return View(questionOption);
        }

        // GET: QuestionOptions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var questionOption = await _context.QuestionOptions.FindAsync(id);
            if (questionOption == null)
            {
                return NotFound();
            }
            ViewData["QuestionId"] = new SelectList(_context.Questions, "QuestionId", "QuestionName", questionOption.QuestionId);
            return View(questionOption);
        }

        // POST: QuestionOptions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("QuestionOptionId,QuestionId,OptionValue,IsCorrect")] QuestionOption questionOption)
        {
            if (id != questionOption.QuestionOptionId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(questionOption);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!QuestionOptionExists(questionOption.QuestionOptionId))
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
            ViewData["QuestionId"] = new SelectList(_context.Questions, "QuestionId", "QuestionName", questionOption.QuestionId);
            return View(questionOption);
        }

        // GET: QuestionOptions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var questionOption = await _context.QuestionOptions
                .Include(q => q.Question)
                .FirstOrDefaultAsync(m => m.QuestionOptionId == id);
            if (questionOption == null)
            {
                return NotFound();
            }

            return View(questionOption);
        }

        // POST: QuestionOptions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var questionOption = await _context.QuestionOptions.FindAsync(id);
            _context.QuestionOptions.Remove(questionOption);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool QuestionOptionExists(int id)
        {
            return _context.QuestionOptions.Any(e => e.QuestionOptionId == id);
        }
    }
}
