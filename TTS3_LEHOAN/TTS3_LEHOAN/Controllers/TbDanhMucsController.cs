using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TTS3_LEHOAN.Models;

namespace TTS3_LEHOAN.Controllers
{
    public class TbDanhMucsController : Controller
    {
        private readonly ShopspContext _context;

        public TbDanhMucsController(ShopspContext context)
        {
            _context = context;
        }

        // GET: TbDanhMucs
        public async Task<IActionResult> Index()
        {
            return View(await _context.TbDanhMucs.ToListAsync());
        }

        // GET: TbDanhMucs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbDanhMuc = await _context.TbDanhMucs
                .FirstOrDefaultAsync(m => m.MaDanhMuc == id);
            if (tbDanhMuc == null)
            {
                return NotFound();
            }

            return View(tbDanhMuc);
        }

        // GET: TbDanhMucs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TbDanhMucs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MaDanhMuc,TenDanhMuc,Mota")] TbDanhMuc tbDanhMuc)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tbDanhMuc);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tbDanhMuc);
        }

        // GET: TbDanhMucs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbDanhMuc = await _context.TbDanhMucs.FindAsync(id);
            if (tbDanhMuc == null)
            {
                return NotFound();
            }
            return View(tbDanhMuc);
        }

        // POST: TbDanhMucs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MaDanhMuc,TenDanhMuc,Mota")] TbDanhMuc tbDanhMuc)
        {
            if (id != tbDanhMuc.MaDanhMuc)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tbDanhMuc);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TbDanhMucExists(tbDanhMuc.MaDanhMuc))
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
            return View(tbDanhMuc);
        }

        // GET: TbDanhMucs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbDanhMuc = await _context.TbDanhMucs
                .FirstOrDefaultAsync(m => m.MaDanhMuc == id);
            if (tbDanhMuc == null)
            {
                return NotFound();
            }

            return View(tbDanhMuc);
        }

        // POST: TbDanhMucs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tbDanhMuc = await _context.TbDanhMucs.FindAsync(id);
            if (tbDanhMuc != null)
            {
                _context.TbDanhMucs.Remove(tbDanhMuc);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TbDanhMucExists(int id)
        {
            return _context.TbDanhMucs.Any(e => e.MaDanhMuc == id);
        }
    }
}
