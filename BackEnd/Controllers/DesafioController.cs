using System.Collections.Specialized;
using System.Linq;
using System.Threading.Tasks;
using BackEnd.Domain;
using BackEnd.Infra.Context;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
namespace BackEnd.Controllers
{
    public class DesafioController : BaseController
    {
        private readonly GRAACCDbContext _context;
        public DesafioController(GRAACCDbContext gRAACCDbContext)
        {
            _context = gRAACCDbContext;
        }

        [HttpPost]
        [AllowAnonymous]
        [Route("v1/desafio/add")]
        //método para adicionar um desafio pelo usuário da empresa
        public async Task<IActionResult> Post([FromBody] DesafioViewModel desafioViewModel)
        {
            // cria lista de notificações
            var notificationList = new ListDictionary();
            // verifica se as classes estão nulas
            if (desafioViewModel == null)
            {
                notificationList.Add("object", "O objeto enviado está nulo!");
                return await Response(null, notificationList);
            }
            // cria premiacao
            var premiacao = new Premiacao(desafioViewModel.Tipo, desafioViewModel.QuantidadePremiados);
            // cria desafio
            var desafio = new Desafio(desafioViewModel.NomeDesafio, desafioViewModel.Descricao, desafioViewModel.Etapas, desafioViewModel.DataInicio, desafioViewModel.DataFinal, premiacao);
            // adiciona no banco
            _context.Add(desafio);
            _context.SaveChanges();
            return await Response(desafio, notificationList);
        }

        [HttpGet]
        [AllowAnonymous]
        [Route("v1/desafio/usuario/{id:int}")]
        // retorna lista de desafios do usuário
        public IActionResult Get(int usuarioId)
        {
            return Ok(_context.DesafioUsuario.Include(x => x.Usuario).Include(x => x.Desafio).Where(x => x.UsuarioId == usuarioId).ToList());
        }

        [HttpGet]
        [AllowAnonymous]
        [Route("v1/desafio/getList")]
        // retorna lista de desafios do usuário
        public IActionResult GetList()
        {
            return Ok(_context.Desafios.ToList());
        }

        [HttpGet]
        [AllowAnonymous]
        [Route("v1/desafio/detalhe/{id:int}")]
        // retorna lista de desafios do usuário
        public IActionResult RetornaDesafioDetalhePorId(int detalheId)
        {
            return Ok(_context.Desafios.Where(x => x.Id == detalheId).ToList());
        }


    }
}