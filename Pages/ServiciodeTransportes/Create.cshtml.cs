using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TransporteSeguro.Data;
using TransporteSeguro.Models;

namespace TransporteSeguro.Pages.ServiciodeTransportes
{
    public class CreateModel : PageModel
    {
        private readonly TransporteSeguroContext _context;

        public CreateModel(TransporteSeguroContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]

        public ServicioTransporte ServicioTransporte { get; set; } = default!;

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid || _context.ServiciodeTransportes == null || ServicioTransporte == null)
            {
                return Page();
            }

            _context.ServiciodeTransportes.Add(ServicioTransporte);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
