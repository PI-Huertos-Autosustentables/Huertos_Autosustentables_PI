using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Huertos_Autosustentables_PI.Data;
using Huertos_Autosustentables_PI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Huertos_Autosustentables_PI.Controllers
{
    public class UsuariosController : Controller
    {
        private readonly ApplicationDbContext _context;
        public UsuariosController(ApplicationDbContext context)
        {
            _context = context;
        }


        // GET: Detalles
        public async Task<IActionResult> Index()
        {
            return View(await _context.Region.ToListAsync());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Required] string NombreRegiones, string CaracterisitcasRegiones, int IdClima)
        {
            if (ModelState.IsValid)
            {
                //var user = await _context.GetUserAsync(User);

                var region = new Region();
                {
                    //region.UserId = await _context.GetUserIdAsync(user);
                    //region.UserId = await _context.GetUserIdAsync(user);
                    region.NombreRegiones = NombreRegiones;
                    region.CaracterisitcasRegiones = CaracterisitcasRegiones;
                    region.IdClima =IdClima;
                }
                if (region != null)
                {
                    _context.Add(region);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
            }
            return View();
        }
    }
}
