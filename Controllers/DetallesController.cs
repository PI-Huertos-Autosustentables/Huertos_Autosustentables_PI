using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Huertos_Autosustentables_PI.Data;
using Huertos_Autosustentables_PI.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Exchange.WebServices.Data;
using System.ComponentModel.DataAnnotations;

namespace Huertos_Autosustentables_PI.Controllers
{
    public class DetallesController : Controller
    {
        private readonly ApplicationDbContext _context;

        //sirve para traer los dato del usuario
        UserManager<IdentityUser> _userManager;

        public DetallesController(ApplicationDbContext context, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;

        }
            // GET: Detalles
            public async Task<IActionResult> Index()
        {
            return View(await _context.DetalleUsersCultivo.Include(d => d.User).ToListAsync());
        }

        // GET: Detalles/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var detalleUsersCultivo = await _context.DetalleUsersCultivo
                .FirstOrDefaultAsync(m => m.IdDetalle == id);
            if (detalleUsersCultivo == null)
            {
                return NotFound();
            }

            return View(detalleUsersCultivo);
        }

        // GET: Detalles/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Detalles/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Required] float MetrosCuadradosDetalle, float PrecioSemillasDetalle,string LugarCultivoDetalle, int IdCultivo)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.GetUserAsync(User);

                var detalle = new DetalleUsersCultivo();
                {
                    detalle.UserId = await _userManager.GetUserIdAsync(user);
                    detalle.MetrosCuadradosDetalle = MetrosCuadradosDetalle;
                    detalle.PrecioSemillasDetalle = PrecioSemillasDetalle;
                    detalle.LugarCultivoDetalle = LugarCultivoDetalle;
                    detalle.IdCultivo = IdCultivo;
                }
                if (detalle != null)
                {
                    _context.Add(detalle);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
            }
            return View();
        }

        // GET: Detalles/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var detalleUsersCultivo = await _context.DetalleUsersCultivo.FindAsync(id);
            if (detalleUsersCultivo == null)
            {
                return NotFound();
            }
            return View(detalleUsersCultivo);
        }

        // POST: Detalles/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdDetalle,MetrosCuadradosDetalle,PrecioSemillasDetalle,LugarCultivoDetalle,IdCultivo")] DetalleUsersCultivo detalleUsersCultivo)
        {
            if (id != detalleUsersCultivo.IdDetalle)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(detalleUsersCultivo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DetalleUsersCultivoExists(detalleUsersCultivo.IdDetalle))
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
            return View(detalleUsersCultivo);
        }

        // GET: Detalles/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var detalleUsersCultivo = await _context.DetalleUsersCultivo
                .FirstOrDefaultAsync(m => m.IdDetalle == id);
            if (detalleUsersCultivo == null)
            {
                return NotFound();
            }

            return View(detalleUsersCultivo);
        }

        // POST: Detalles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var detalleUsersCultivo = await _context.DetalleUsersCultivo.FindAsync(id);
            _context.DetalleUsersCultivo.Remove(detalleUsersCultivo);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DetalleUsersCultivoExists(int id)
        {
            return _context.DetalleUsersCultivo.Any(e => e.IdDetalle == id);
        }
    }
}
