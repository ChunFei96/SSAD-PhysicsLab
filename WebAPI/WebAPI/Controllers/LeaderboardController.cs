using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DAL;
using DAL.Entities;
using Services.Leaderboard;

namespace WebAPI.Controllers
{
    [Route("api/leaderboard")]
    [ApiController]
    public class LeaderboardController : Controller
    {
        private readonly ILeaderboardService _leaderboardService;

        public LeaderboardController(ILeaderboardService leaderboardService)
        {
            _leaderboardService = leaderboardService;
        }

        // GET: Leaderboard
        [Route("GetLeaderboard")]
        public IActionResult Index()
        {
            var eFDbContext = _leaderboardService.GetLeaderboard();
            return Ok(eFDbContext);
        }

        //// GET: Leaderboard/Details/5
        //public async Task<IActionResult> Details(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var leaderboard = await _context.Leaderboard
        //        .Include(l => l.Topic)
        //        .FirstOrDefaultAsync(m => m.Id == id);
        //    if (leaderboard == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(leaderboard);
        //}

        //// GET: Leaderboard/Create
        //public IActionResult Create()
        //{
        //    ViewData["TopicId"] = new SelectList(_context.Topics, "Id", "Id");
        //    return View();
        //}

        //// POST: Leaderboard/Create
        //// To protect from overposting attacks, enable the specific properties you want to bind to.
        //// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Create([Bind("TopicId,Type,Id,Status,CreatedBy,ModifiedBy,CreatedTimeStamp,ModifiedTimeStamp")] Leaderboard leaderboard)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        _context.Add(leaderboard);
        //        await _context.SaveChangesAsync();
        //        return RedirectToAction(nameof(Index));
        //    }
        //    ViewData["TopicId"] = new SelectList(_context.Topics, "Id", "Id", leaderboard.TopicId);
        //    return View(leaderboard);
        //}

        //// GET: Leaderboard/Edit/5
        //public async Task<IActionResult> Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var leaderboard = await _context.Leaderboard.FindAsync(id);
        //    if (leaderboard == null)
        //    {
        //        return NotFound();
        //    }
        //    ViewData["TopicId"] = new SelectList(_context.Topics, "Id", "Id", leaderboard.TopicId);
        //    return View(leaderboard);
        //}

        //// POST: Leaderboard/Edit/5
        //// To protect from overposting attacks, enable the specific properties you want to bind to.
        //// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Edit(int id, [Bind("TopicId,Type,Id,Status,CreatedBy,ModifiedBy,CreatedTimeStamp,ModifiedTimeStamp")] Leaderboard leaderboard)
        //{
        //    if (id != leaderboard.Id)
        //    {
        //        return NotFound();
        //    }

        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            _context.Update(leaderboard);
        //            await _context.SaveChangesAsync();
        //        }
        //        catch (DbUpdateConcurrencyException)
        //        {
        //            if (!LeaderboardExists(leaderboard.Id))
        //            {
        //                return NotFound();
        //            }
        //            else
        //            {
        //                throw;
        //            }
        //        }
        //        return RedirectToAction(nameof(Index));
        //    }
        //    ViewData["TopicId"] = new SelectList(_context.Topics, "Id", "Id", leaderboard.TopicId);
        //    return View(leaderboard);
        //}

        //// GET: Leaderboard/Delete/5
        //public async Task<IActionResult> Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var leaderboard = await _context.Leaderboard
        //        .Include(l => l.Topic)
        //        .FirstOrDefaultAsync(m => m.Id == id);
        //    if (leaderboard == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(leaderboard);
        //}

        //// POST: Leaderboard/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> DeleteConfirmed(int id)
        //{
        //    var leaderboard = await _context.Leaderboard.FindAsync(id);
        //    _context.Leaderboard.Remove(leaderboard);
        //    await _context.SaveChangesAsync();
        //    return RedirectToAction(nameof(Index));
        //}

        //private bool LeaderboardExists(int id)
        //{
        //    return _context.Leaderboard.Any(e => e.Id == id);
        //}
    }
}
