using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Security.Claims;
using TransporteSeguro.Consultas;
using TransporteSeguro.Models;

namespace TransporteSeguro.Pages.Account
{
    public class LoginModel : PageModel
    {
        private UserConsulta _consulta;

        public LoginModel(UserConsulta consulta)
        {
            _consulta = consulta;
        }

        [BindProperty]
        public User User { get; set; }
        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid) return Page();

            IEnumerable<User> userList = _consulta.GetByValue(User.Email);

            if (userList.Any())
            {
                User userinform
                    = userList.First();

                if (userinform.Password == User.Password)
                {

                    var claims = new List<Claim>
                    {
                         new Claim(ClaimTypes.Name, "admin"),
                         new Claim(ClaimTypes.Email, User.Email),
                    };

                    var identity = new ClaimsIdentity(claims, "MyCookieAuth");

                    ClaimsPrincipal claimsPrincipal = new ClaimsPrincipal(identity);

                    await HttpContext.SignInAsync("MyCookieAuth", claimsPrincipal);

                    return RedirectToPage("/Index");
                }
            }

            return Page();

        }
    }
}
