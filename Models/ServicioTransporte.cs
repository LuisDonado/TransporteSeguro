namespace TransporteSeguro.Models
{
	public class ServicioTransporte
	{
		public int Id { get; set; }
		public DateTime Fecha { get; set; }
		public string Conductor { get; set; }
		public string ClienteNombre { get; set; }
	}
}
