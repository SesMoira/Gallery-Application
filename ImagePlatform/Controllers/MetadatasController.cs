using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ImagePlatform.Data;
using ImagePlatform.Models;

namespace ImagePlatform.Controllers
{
    public class MetadatasController : Controller
    {
        private readonly ImagePlatformDBContext _context;

        public MetadatasController(ImagePlatformDBContext context)
        {
            _context = context;
        }

        // GET: Metadatas
        public async Task<IActionResult> Index()
        {
            return View(await _context.Metadata.ToListAsync());
        }

        // GET: Metadatas/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var metadata = await _context.Metadata
                .FirstOrDefaultAsync(m => m.UserId == id);
            if (metadata == null)
            {
                return NotFound();
            }

            return View(metadata);
        }

        // GET: Metadatas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Metadatas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("UserId,Title,CapturedBy,CapturedDate,Geolocation,Url,Description,ImageId")] Metadata metadata)
        {
            if (ModelState.IsValid)
            {
                _context.Add(metadata);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(metadata);
        }

        // GET: Metadatas/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var metadata = await _context.Metadata.FindAsync(id);
            if (metadata == null)
            {
                return NotFound();
            }
            return View(metadata);
        }

        // POST: Metadatas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("UserId,Title,CapturedBy,CapturedDate,Geolocation,Url,Description,ImageId")] Metadata metadata)
        {
            if (id != metadata.UserId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(metadata);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MetadataExists(metadata.UserId))
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
            return View(metadata);
        }

        // GET: Metadatas/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var metadata = await _context.Metadata
                .FirstOrDefaultAsync(m => m.UserId == id);
            if (metadata == null)
            {
                return NotFound();
            }

            return View(metadata);
        }

        // POST: Metadatas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var metadata = await _context.Metadata.FindAsync(id);
            _context.Metadata.Remove(metadata);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MetadataExists(string id)
        {
            return _context.Metadata.Any(e => e.UserId == id);
        }
    }
}
