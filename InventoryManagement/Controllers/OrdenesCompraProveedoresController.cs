using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using InventoryManagement.Data;
using InventoryManagement.Models;

namespace InventoryManagement.Controllers
{
    public class OrdenesCompraProveedoresController : Controller
    {
        private readonly ApplicationDbContext _context;

        public OrdenesCompraProveedoresController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: OrdenesCompraProveedores
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.OrdenesCompraProveedores.Include(o => o.OrdenCompra).Include(o => o.Proveedor);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: OrdenesCompraProveedores/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ordenCompraProveedor = await _context.OrdenesCompraProveedores
                .Include(o => o.OrdenCompra)
                .Include(o => o.Proveedor)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (ordenCompraProveedor == null)
            {
                return NotFound();
            }

            return View(ordenCompraProveedor);
        }

        // GET: OrdenesCompraProveedores/Create
        public IActionResult Create()
        {
            ViewData["IdOrdenCompra"] = new SelectList(_context.OrdenesCompra, "Id", "Id");
            ViewData["IdProveedor"] = new SelectList(_context.Proveedores, "Id", "Id");
            return View();
        }

        // POST: OrdenesCompraProveedores/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,IdOrdenCompra,IdProveedor")] OrdenCompraProveedor ordenCompraProveedor)
        {
            if (ModelState.IsValid)
            {
                _context.Add(ordenCompraProveedor);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdOrdenCompra"] = new SelectList(_context.OrdenesCompra, "Id", "Id", ordenCompraProveedor.IdOrdenCompra);
            ViewData["IdProveedor"] = new SelectList(_context.Proveedores, "Id", "Id", ordenCompraProveedor.IdProveedor);
            return View(ordenCompraProveedor);
        }

        // GET: OrdenesCompraProveedores/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ordenCompraProveedor = await _context.OrdenesCompraProveedores.FindAsync(id);
            if (ordenCompraProveedor == null)
            {
                return NotFound();
            }
            ViewData["IdOrdenCompra"] = new SelectList(_context.OrdenesCompra, "Id", "Id", ordenCompraProveedor.IdOrdenCompra);
            ViewData["IdProveedor"] = new SelectList(_context.Proveedores, "Id", "Id", ordenCompraProveedor.IdProveedor);
            return View(ordenCompraProveedor);
        }

        // POST: OrdenesCompraProveedores/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,IdOrdenCompra,IdProveedor")] OrdenCompraProveedor ordenCompraProveedor)
        {
            if (id != ordenCompraProveedor.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ordenCompraProveedor);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OrdenCompraProveedorExists(ordenCompraProveedor.Id))
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
            ViewData["IdOrdenCompra"] = new SelectList(_context.OrdenesCompra, "Id", "Id", ordenCompraProveedor.IdOrdenCompra);
            ViewData["IdProveedor"] = new SelectList(_context.Proveedores, "Id", "Id", ordenCompraProveedor.IdProveedor);
            return View(ordenCompraProveedor);
        }

        // GET: OrdenesCompraProveedores/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ordenCompraProveedor = await _context.OrdenesCompraProveedores
                .Include(o => o.OrdenCompra)
                .Include(o => o.Proveedor)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (ordenCompraProveedor == null)
            {
                return NotFound();
            }

            return View(ordenCompraProveedor);
        }

        // POST: OrdenesCompraProveedores/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var ordenCompraProveedor = await _context.OrdenesCompraProveedores.FindAsync(id);
            if (ordenCompraProveedor != null)
            {
                _context.OrdenesCompraProveedores.Remove(ordenCompraProveedor);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OrdenCompraProveedorExists(int id)
        {
            return _context.OrdenesCompraProveedores.Any(e => e.Id == id);
        }
    }
}
