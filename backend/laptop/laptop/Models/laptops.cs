using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace laptop.Models
{
	public class laptops
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.None)]
		public int Column_1 { get; set; }
		public string Company { get; set; }
		public string TypeName { get; set; }
		public int Inches { get; set; }
		public string ScreenResolution { get; set; }
		public string Cpu { get; set; }
		public string Ram { get; set; }
		public string Memory { get; set; }
		public string Gpu { get; set; }
		public string OpSys { get; set; }
		public string Weight { get; set; }
		public double Price { get; set; }
	}
}
