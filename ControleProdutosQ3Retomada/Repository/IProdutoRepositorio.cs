using ControleProdutosQ3Retomada.Models;

namespace ControleProdutosQ3Retomada.Repository
{
	public interface IProdutoRepositorio
	{
		Task<List<ProdutoModel>> BuscarTodos();
		Task<ProdutoModel> Adicionar(ProdutoModel produto);
		Task<ProdutoModel> ListarPorId(long id);
		Task<ProdutoModel> Atualizar(ProdutoModel produto);
		Task<bool> AtivarDesativar(long id);
		Task<bool> Apagar(long id);
	}
}
