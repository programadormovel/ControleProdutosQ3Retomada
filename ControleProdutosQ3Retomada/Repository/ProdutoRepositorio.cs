using ControleProdutosQ3Retomada.Data;
using ControleProdutosQ3Retomada.Models;

namespace ControleProdutosQ3Retomada.Repository
{
	public class ProdutoRepositorio : IProdutoRepositorio
	{
		private readonly BancoContext _bancoContext;

		public ProdutoRepositorio(BancoContext bancoContext)
		{
			_bancoContext = bancoContext;
		}
		
		ProdutoModel IProdutoRepositorio.Adicionar(ProdutoModel produto)
		{
			_bancoContext.Produto.Add(produto);
			throw new NotImplementedException();
		}

		List<ProdutoModel> IProdutoRepositorio.BuscarTodos()
		{
			throw new NotImplementedException();
		}
	}
}
