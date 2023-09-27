using ControleProdutosQ3Retomada.Models;

namespace ControleProdutosQ3Retomada.Repository
{
	public interface IProdutoRepositorio
	{
		Task<List<ProdutoModel>> BuscarTodos();
		Task<ProdutoModel> Adicionar(ProdutoModel produto);
	}
}
