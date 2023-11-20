using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TransporteSeguro.Data;
using TransporteSeguro.Models;

namespace TransporteSeguro.Pages.ServiciodeTransportes
{
    public class DeleteModel : PageModel
    {
        private readonly TransporteSeguroContext _context;

        public DeleteModel(TransporteSeguroContext context)
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
            else
            {
                ServicioTransporte = serviciotransporte;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.ServiciodeTransportes == null)
            {
                return NotFound();
            }

            var serviciotransporte = await _context.ServiciodeTransportes.FindAsync(id);

            if (serviciotransporte != null)
            {
                ServicioTransporte = serviciotransporte;
                _context.ServiciodeTransportes.Remove(ServicioTransporte);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
