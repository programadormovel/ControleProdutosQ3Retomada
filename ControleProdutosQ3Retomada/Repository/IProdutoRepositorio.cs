using ControleProdutosQ3Retomada.Models;

namespace ControleProdutosQ3Retomada.Repository
{
	public interface IProdutoRepositorio
	{
		List<ProdutoModel> BuscarTodos();
		ProdutoModel Adicionar(ProdutoModel produto);
	}
}
