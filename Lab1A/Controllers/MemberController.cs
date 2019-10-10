// I, Freny Patel, student number 000744054, certify that this material is my
// original work. No other person's work has been used without due
// acknowledgement and I have not made my work available to anyone else.
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Lab1A.Models;

namespace Lab1A.Controllers
{
    public class MemberController : Controller
    {
        private readonly Lab1AContext _context;

        public MemberController(Lab1AContext context)
        {
            _context = context;
        }
        public async Task<string> Seed()
        {
            int numberOfMembers = 0;
            if (_context.Member.Count() == 0)
            {
                Member mem1 = new Member { UserName = "John12", FirstName = "John", LastName = "Smith", Company = "Indigo", BirthDate = "1990-06-21", Email = "john1@gmail.com", Position = "Senior Manager" };
                Member mem2 = new Member { UserName = "LilyR", FirstName = "Lily", LastName = "Rose", Company = "BMW", BirthDate = "1985-01-01", Email = "lily3@hotmail.com", Position = "Sale Associate" };
                Member mem3 = new Member { UserName = "Hanry43", FirstName = "Hanry", LastName = "Mac", Company = "Toyoto", BirthDate = "1995-07-28", Email = "hanry@yahoo.in", Position = "Merchandise Manager" };
                Member mem4 = new Member { UserName = "Nick012", FirstName = "Nick", LastName = "Jackson", Company = "BMW", BirthDate = "1979-12-16", Email = "NikcJackson@gmail.com", Position = "Senior Manager" };

                _context.AddRange(mem1, mem2, mem3, mem4);
                await _context.SaveChangesAsync();
                numberOfMembers = 4;
            }

            return $"{numberOfMembers} Members Added";
        }
        // GET: Member
        public async Task<IActionResult> Index()
        {
            return View(await _context.Member.ToListAsync());
        }

        // GET: Member/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var member = await _context.Member
                .FirstOrDefaultAsync(m => m.id == id);
            if (member == null)
            {
                return NotFound();
            }

            return View(member);
        }

        // GET: Member/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Member/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,FirstName,LastName,UserName,Email,Company,Position,BirthDate")] Member member)
        {
            if (ModelState.IsValid)
            {
                _context.Add(member);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(member);
        }

        // GET: Member/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var member = await _context.Member.FindAsync(id);
            if (member == null)
            {
                return NotFound();
            }
            return View(member);
        }

        // POST: Member/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,FirstName,LastName,UserName,Email,Company,Position,BirthDate")] Member member)
        {
            if (id != member.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(member);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MemberExists(member.id))
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
            return View(member);
        }

        // GET: Member/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var member = await _context.Member
                .FirstOrDefaultAsync(m => m.id == id);
            if (member == null)
            {
                return NotFound();
            }

            return View(member);
        }

        // POST: Member/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var member = await _context.Member.FindAsync(id);
            _context.Member.Remove(member);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MemberExists(int id)
        {
            return _context.Member.Any(e => e.id == id);
        }
    }
}
