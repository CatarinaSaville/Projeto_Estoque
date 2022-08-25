using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EvoEstoque.Data;
using EvoEstoque.Models;

namespace EvoEstoque.Controllers
{
    public class MercadoriasController : Controller
    {
        private readonly Contexto _context;

        public MercadoriasController(Contexto context)
        {
            _context = context;
        }

        // GET: Mercadorias
        public async Task<IActionResult> Index()
        {
              return _context.Mercadoria != null ? 
                          View(await _context.Mercadoria.ToListAsync()) :
                          Problem("Entity set 'Contexto.Mercadoria'  is null.");
        }

        // GET: Mercadorias/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Mercadoria == null)
            {
                return NotFound();
            }

            var mercadoria = await _context.Mercadoria
                .FirstOrDefaultAsync(m => m.Id == id);
            if (mercadoria == null)
            {
                return NotFound();
            }

            return View(mercadoria);
        }

        // GET: Mercadorias/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Mercadorias/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Descricao,Unidade,Estoque")] Mercadoria mercadoria)
        {
            if (ModelState.IsValid)
            {
                _context.Add(mercadoria);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(mercadoria);
        }

        // GET: Mercadorias/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Mercadoria == null)
            {
                return NotFound();
            }

            var mercadoria = await _context.Mercadoria.FindAsync(id);
            if (mercadoria == null)
            {
                return NotFound();
            }
            return View(mercadoria);
        }

        // POST: Mercadorias/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Descricao,Unidade,Estoque")] Mercadoria mercadoria)
        {
            if (id != mercadoria.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(mercadoria);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MercadoriaExists(mercadoria.Id))
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
            return View(mercadoria);
        }

        // GET: Mercadorias/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Mercadoria == null)
            {
                return NotFound();
            }

            var mercadoria = await _context.Mercadoria
                .FirstOrDefaultAsync(m => m.Id == id);
            if (mercadoria == null)
            {
                return NotFound();
            }

            return View(mercadoria);
        }

        // POST: Mercadorias/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Mercadoria == null)
            {
                return Problem("Entity set 'Contexto.Mercadoria'  is null.");
            }
            var mercadoria = await _context.Mercadoria.FindAsync(id);
            if (mercadoria != null)
            {
                _context.Mercadoria.Remove(mercadoria);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MercadoriaExists(int id)
        {
          return (_context.Mercadoria?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
