using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace ControleProdutosQ3Retomada.Models
{
	[Index(nameof(CodigoDeBarras), IsUnique = true)]
	public class ProdutoModel
	{
        public int Id { get; set; }
		
		[Required(ErrorMessage ="Campo Obrigatório!")]
		[StringLength(12, MinimumLength = 12, ErrorMessage = "Mínimo de 12 caracteres!")]
		[RegularExpression(@"^[0-9]+$", ErrorMessage ="Este campo aceita apenas números.")]
		public string CodigoDeBarras { get; set; }

		//[RegularExpression(@"^[A-Z]+[a-zA-Z\s]*$")]
		[Required(ErrorMessage = "Campo Obrigatório!")]
		public string Descricao { get; set; }

		//[Range(typeof(DateTime), minimum:"23/09/2023", maximum: "24/09/2024")]
		[DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", 
			ApplyFormatInEditMode=true)]
		[DataType(DataType.Date)]	
		public DateTime DataDeValidade { get; set;}

		[DataType(DataType.DateTime)]
		public DateTime DataDeRegistro { get; set; }

		[Range(1, 1000)]
		public int Quantidade { get; set; }

		[DataType(DataType.Currency)]
		[Column(TypeName = "decimal(18,2)")]
		public decimal Valor { get; set;}
		
		[MaybeNull]
		public string? NomeDaFoto { get; set; }

		[MaybeNull]
		public byte[]? Foto { get; set; }

		[Required(ErrorMessage = "Campo Obrigatório!")]
		public bool Ativo { get; set; }	


    }
}
