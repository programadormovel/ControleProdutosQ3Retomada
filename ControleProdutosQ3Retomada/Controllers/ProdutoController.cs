using ControleProdutosQ3Retomada.Models;
using ControleProdutosQ3Retomada.Repository;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using IHostingEnvironment = Microsoft.AspNetCore.Hosting.IHostingEnvironment;

namespace ControleProdutosQ3Retomada.Controllers
{
	public class ProdutoController : Controller
	{
		// Injeção de Dependência
		private IHostingEnvironment Environment;

		private readonly IProdutoRepositorio _produtoRepositorio;

		public ProdutoController(IProdutoRepositorio produtoRepositorio, 
			IHostingEnvironment _envinronment)
		{
			_produtoRepositorio = produtoRepositorio;
			Environment = _envinronment;
		}

		public async Task<IActionResult> Index()
		{
			List<ProdutoModel> produtos = await _produtoRepositorio.BuscarTodos();

			ViewBag.Produtos = "outro objeto";	

			return await Task.FromResult(View(produtos));
		}

		public async Task<IActionResult> Criar()
		{
			return await Task.FromResult(View());
		}
		
		public async Task<IActionResult> Editar(long id)
		{
			ProdutoModel produto = await _produtoRepositorio.ListarPorId(id);

			return await Task.FromResult(View(produto));
		}
		
		[HttpPost]
		public async Task<IActionResult> Alterar(ProdutoModel produto, IFormFile? imagemCarregada, DateTime dataAlterada)
		{
            List<ValidationResult> results = new List<ValidationResult>();
            ValidationContext context = new ValidationContext(produto);

            bool isValid = Validator.TryValidateObject(produto, context, results, true);
            if (!isValid)
            {
                foreach (ValidationResult validationResult in results)
                {
                    return await Task.FromResult(View(produto));
                }
            }

            string caminho = this.Environment.WebRootPath;
            caminho = Path.Combine(caminho, "Uploads");
            if (!Directory.Exists(caminho))
            {
                Directory.CreateDirectory(caminho);
            }
            string nomeArquivo = Path.GetFileName(imagemCarregada!.FileName);
            using (FileStream stream = new FileStream(Path.Combine(caminho, nomeArquivo), FileMode.Create))
            {
                imagemCarregada.CopyTo(stream);
                produto.NomeDaFoto = nomeArquivo;
            }
            produto.Foto = Util.ReadFully2(Path.Combine(caminho, nomeArquivo));
			produto.DataDeValidade = dataAlterada;
			produto.Ativo = true;

            await _produtoRepositorio.Atualizar(produto);

			return await Task.FromResult(RedirectToAction("Index", "Produto"));
		}

		[HttpPost]
		public async Task<IActionResult> Criar(ProdutoModel produto, IFormFile? imagemCarregada)
		{
			List<ValidationResult> results = new List<ValidationResult>();
			ValidationContext context = new ValidationContext(produto);

			bool isValid = Validator.TryValidateObject(produto, context, results, true);
			if (!isValid)
			{
				foreach (ValidationResult validationResult in results)
				{
					return await Task.FromResult(View(produto));
				}
			}

			// Carregamento da Imagem
			string caminho = this.Environment.WebRootPath;
			caminho = Path.Combine(caminho, "Uploads");
			if (!Directory.Exists(caminho))
			{
				Directory.CreateDirectory(caminho);
			}
			string nomeArquivo = Path.GetFileName(imagemCarregada!.FileName);
			using(FileStream stream = new FileStream(Path.Combine(caminho, nomeArquivo), FileMode.Create))
			{
				imagemCarregada.CopyTo(stream);
				produto.NomeDaFoto = nomeArquivo;
			}
			produto.Foto = Util.ReadFully2(Path.Combine(caminho, nomeArquivo));

			produto.DataDeRegistro = DateTime.Now;
			produto.Ativo = true;

			await _produtoRepositorio.Adicionar(produto);

			return await Task.FromResult(RedirectToAction("Index"));
		}

	}
}
