using Microsoft.EntityFrameworkCore;
using TransporteSeguro.Models;

namespace TransporteSeguro.Data
{
	public class TransporteSeguroContext : DbContext
	{

		public TransporteSeguroContext(DbContextOptions options) : base(options)
		{
		}

		public DbSet<Cliente> Clientes { get; set; }
		public DbSet<ServicioTransporte> ServiciodeTransportes { get; set; }
		public DbSet<User> Users { get; set; }
	}
}
