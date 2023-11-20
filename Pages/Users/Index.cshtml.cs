using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TransporteSeguro.Data;
using TransporteSeguro.Models;

namespace TransporteSeguro.Pages.Users
{
    [Authorize]
    public class IndexModel : PageModel
    {
        private readonly TransporteSeguroContext _context;

        public IndexModel(TransporteSeguroContext context)
        {
            _context = context;
        }

        public IList<User> Users { get; set; }

        public async Task OnGetAsync()
        {
            Users = await _context.Users.ToListAsync();
        }

        public async Task<IActionResult> OnPostDeleteAsync(int id)
        {
            var user = await _context.Users.FindAsync(id);

            if (user == null)
            {
                return NotFound();
            }

            _context.Users.Remove(user);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}

