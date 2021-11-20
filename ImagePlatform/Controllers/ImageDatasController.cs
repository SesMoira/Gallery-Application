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
    public class ImageDatasController : Controller
    {
        private readonly ImagePlatformDBContext _context;

        public ImageDatasController(ImagePlatformDBContext context)
        {
            _context = context;
        }

        // GET: ImageDatas
        public async Task<IActionResult> Index()
        {
            return View(await _context.ImageData.ToListAsync());
        }

        // GET: ImageDatas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var imageData = await _context.ImageData
                .FirstOrDefaultAsync(m => m.ImageId == id);
            if (imageData == null)
            {
                return NotFound();
            }

            return View(imageData);
        }

        // GET: ImageDatas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ImageDatas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ImageId,ImageTitle,CapturedBy,CapturedDate,Geolocation,ImageUrl,ImageDescription,ImageTags")] ImageData imageData)
        {
            if (ModelState.IsValid)
            {
                ImageData file = 
                _context.Add(imageData);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(imageData);
        }

        // GET: ImageDatas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var imageData = await _context.ImageData.FindAsync(id);
            if (imageData == null)
            {
                return NotFound();
            }
            return View(imageData);
        }

        // POST: ImageDatas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ImageId,ImageTitle,CapturedBy,CapturedDate,Geolocation,ImageUrl,ImageDescription,ImageTags")] ImageData imageData)
        {
            if (id != imageData.ImageId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(imageData);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ImageDataExists(imageData.ImageId))
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
            return View(imageData);
        }

        // GET: ImageDatas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var imageData = await _context.ImageData
                .FirstOrDefaultAsync(m => m.ImageId == id);
            if (imageData == null)
            {
                return NotFound();
            }

            return View(imageData);
        }

        // POST: ImageDatas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var imageData = await _context.ImageData.FindAsync(id);
            _context.ImageData.Remove(imageData);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ImageDataExists(int id)
        {
            return _context.ImageData.Any(e => e.ImageId == id);
        }
    }
}
