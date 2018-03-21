using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using InvistaEFSolucao.Models;

namespace InvistaEFSolucao.Controllers
{
    public class IndicadorBiologicoesController : Controller
    {
        private readonly BloggingContext _context;

        public IndicadorBiologicoesController(BloggingContext context)
        {
            _context = context;
        }

        // GET: IndicadorBiologicoes
        public async Task<IActionResult> Index()
        {
            return View(await _context.IndicadoresBiologicos.ToListAsync());
        }

        // GET: IndicadorBiologicoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var indicadorBiologico = await _context.IndicadoresBiologicos
                .SingleOrDefaultAsync(m => m.IndicadorBiologicoID == id);
            if (indicadorBiologico == null)
            {
                return NotFound();
            }

            return View(indicadorBiologico);
        }

        // GET: IndicadorBiologicoes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: IndicadorBiologicoes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IndicadorBiologicoID,Produto,Microorganismo,CorOriginal,ValorD,ValorZ,ValorN,CorPosterior")] IndicadorBiologico indicadorBiologico)
        {
            if (ModelState.IsValid)
            {
                _context.Add(indicadorBiologico);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(indicadorBiologico);
        }

        // GET: IndicadorBiologicoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var indicadorBiologico = await _context.IndicadoresBiologicos.SingleOrDefaultAsync(m => m.IndicadorBiologicoID == id);
            if (indicadorBiologico == null)
            {
                return NotFound();
            }
            return View(indicadorBiologico);
        }

        // POST: IndicadorBiologicoes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IndicadorBiologicoID,Produto,Microorganismo,CorOriginal,ValorD,ValorZ,ValorN,CorPosterior")] IndicadorBiologico indicadorBiologico)
        {
            if (id != indicadorBiologico.IndicadorBiologicoID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(indicadorBiologico);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!IndicadorBiologicoExists(indicadorBiologico.IndicadorBiologicoID))
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
            return View(indicadorBiologico);
        }

        // GET: IndicadorBiologicoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var indicadorBiologico = await _context.IndicadoresBiologicos
                .SingleOrDefaultAsync(m => m.IndicadorBiologicoID == id);
            if (indicadorBiologico == null)
            {
                return NotFound();
            }

            return View(indicadorBiologico);
        }

        // POST: IndicadorBiologicoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var indicadorBiologico = await _context.IndicadoresBiologicos.SingleOrDefaultAsync(m => m.IndicadorBiologicoID == id);
            _context.IndicadoresBiologicos.Remove(indicadorBiologico);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool IndicadorBiologicoExists(int id)
        {
            return _context.IndicadoresBiologicos.Any(e => e.IndicadorBiologicoID == id);
        }
    }
}
