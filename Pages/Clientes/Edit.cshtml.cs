using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TransporteSeguro.Data;
using TransporteSeguro.Models;

namespace TransporteSeguro.Pages.Clientes
{
    public class EditModel : PageModel
    {
        private readonly TransporteSeguroContext _context;

        public EditModel(TransporteSeguroContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Cliente Cliente { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Clientes == null)
            {
                return NotFound();
            }

            var cliente = await _context.Clientes.FirstOrDefaultAsync(m => m.Id == id);
            if (cliente == null)
            {
                return NotFound();
            }
            Cliente = cliente;
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Cliente).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ClientesExists(Cliente.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }

            }

            return RedirectToPage("./index");
        }

        private bool ClientesExists(int id)
        {
            return (_context.Clientes?.Any(c => c.Id == id)).GetValueOrDefault();
        }
    }
}

