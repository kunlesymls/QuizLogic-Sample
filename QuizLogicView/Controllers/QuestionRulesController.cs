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
    public class QuestionRulesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public QuestionRulesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: QuestionRules
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.QuestionRules.Include(q => q.Subject);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: QuestionRules/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var questionRule = await _context.QuestionRules
                .Include(q => q.Subject)
                .FirstOrDefaultAsync(m => m.QuestionRuleId == id);
            if (questionRule == null)
            {
                return NotFound();
            }

            return View(questionRule);
        }

        // GET: QuestionRules/Create
        public IActionResult Create()
        {
            ViewData["SubjectId"] = new SelectList(_context.Subjects, "SubjectId", "SubjectId");
            return View();
        }

        // POST: QuestionRules/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("QuestionRuleId,SubjectId,ScorePerQuestion,AnswerAllQuestion,TotalQuestion,UseUnlimitedTime,MaximumTime,StartDate,EndDate,NoOfAllowedAttempt,NoOfAttemptPerDay")] QuestionRule questionRule)
        {
            if (ModelState.IsValid)
            {
                _context.Add(questionRule);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["SubjectId"] = new SelectList(_context.Subjects, "SubjectId", "SubjectId", questionRule.SubjectId);
            return View(questionRule);
        }

        // GET: QuestionRules/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var questionRule = await _context.QuestionRules.FindAsync(id);
            if (questionRule == null)
            {
                return NotFound();
            }
            ViewData["SubjectId"] = new SelectList(_context.Subjects, "SubjectId", "SubjectId", questionRule.SubjectId);
            return View(questionRule);
        }

        // POST: QuestionRules/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("QuestionRuleId,SubjectId,ScorePerQuestion,AnswerAllQuestion,TotalQuestion,UseUnlimitedTime,MaximumTime,StartDate,EndDate,NoOfAllowedAttempt,NoOfAttemptPerDay")] QuestionRule questionRule)
        {
            if (id != questionRule.QuestionRuleId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(questionRule);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!QuestionRuleExists(questionRule.QuestionRuleId))
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
            ViewData["SubjectId"] = new SelectList(_context.Subjects, "SubjectId", "SubjectId", questionRule.SubjectId);
            return View(questionRule);
        }

        // GET: QuestionRules/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var questionRule = await _context.QuestionRules
                .Include(q => q.Subject)
                .FirstOrDefaultAsync(m => m.QuestionRuleId == id);
            if (questionRule == null)
            {
                return NotFound();
            }

            return View(questionRule);
        }

        // POST: QuestionRules/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var questionRule = await _context.QuestionRules.FindAsync(id);
            _context.QuestionRules.Remove(questionRule);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool QuestionRuleExists(int id)
        {
            return _context.QuestionRules.Any(e => e.QuestionRuleId == id);
        }
    }
}
