using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TransporteSeguro.Data;
using TransporteSeguro.Models;


namespace TransporteSeguro.Pages.ServiciodeTransportes
{
	[Authorize]
	public class IndexModel : PageModel
    {
        private readonly TransporteSeguroContext _context;

        public IndexModel(TransporteSeguroContext context)
        {
            _context = context;
        }

        public IList<ServicioTransporte> ServiciodeTransportes { get; set; }

        public async Task OnGetAsync()
        {
            ServiciodeTransportes = await _context.ServiciodeTransportes.ToListAsync();
        }

        public async Task<IActionResult> OnPostDeleteAsync(int id)
        {
            var serviciotransporte = await _context.ServiciodeTransportes.FindAsync(id);

            if (serviciotransporte == null)
            {
                return NotFound();
            }

            _context.ServiciodeTransportes.Remove(serviciotransporte);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}


