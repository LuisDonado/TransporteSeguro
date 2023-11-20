using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TransporteSeguro.Data;
using TransporteSeguro.Models;

namespace TransporteSeguro.Pages.ServiciodeTransportes
{
    public class EditModel : PageModel
    {
        private readonly TransporteSeguroContext _context;

        public EditModel(TransporteSeguroContext context)
        {
            _context = context;
        }

        [BindProperty]
        public ServicioTransporte ServicioTransporte { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.ServiciodeTransportes == null)
            {
                return NotFound();
            }

            var serviciotransporte = await _context.ServiciodeTransportes.FirstOrDefaultAsync(m => m.Id == id);
            if (serviciotransporte == null)
            {
                return NotFound();
            }
            ServicioTransporte = serviciotransporte;
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(ServicioTransporte).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ServiciodeTransportesExists(ServicioTransporte.Id))
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

        private bool ServiciodeTransportesExists(int id)
        {
            return (_context.ServiciodeTransportes?.Any(c => c.Id == id)).GetValueOrDefault();
        }
    }
}

