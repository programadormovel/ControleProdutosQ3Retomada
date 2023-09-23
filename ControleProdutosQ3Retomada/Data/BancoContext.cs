using ControleProdutosQ3Retomada.Models;
using Microsoft.EntityFrameworkCore;

namespace ControleProdutosQ3Retomada.Data
{
	public class BancoContext : DbContext
	{
		public BancoContext(DbContextOptions<BancoContext> options) : 
			base(options)
			{
				
			}

		public DbSet<ProdutoModel> Produto { get; set; }
	}
}
