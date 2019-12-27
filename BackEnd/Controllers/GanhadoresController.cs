using System.Collections.Specialized;
using System.Linq;
using System.Threading.Tasks;
using BackEnd.Domain;
using BackEnd.Domain.Interfaces;
using BackEnd.Infra.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BackEnd.Controllers
{
    public class GanhadorController : BaseController
    {
        private readonly GRAACCDbContext _context;
        private readonly IUser _user;
        public GanhadorController(GRAACCDbContext context, IUser user)
        {
            _context = context;
            _user = user;
        }
        [HttpPost]
        [Route("v1/ganhador/add")]
        public async Task<IActionResult> Post([FromBody] GanhadorViewModel ganhadorViewModel)
        {
            // cria lista de notificações
            var notificationList = new ListDictionary();

            // verifica se as classes estão nulas
            if (ganhadorViewModel == null)
            {
                notificationList.Add("object", "O objeto enviado está nulo!");
                return await Response(null, notificationList);
            }
            // recupera o usuário
            // recuperar usuario pelo id do ganhador view model
            var usuarioGanhador = _context.Usuarios.FirstOrDefault(x => x.Id == ganhadorViewModel.UsuarioGanhadorId);
            // recupera o desafio com a lista de ganhadores
            var desafio = _context.Desafios.Include(x => x.ListaGanhadores).ThenInclude(x => x.Usuario).FirstOrDefault(x => x.Id == ganhadorViewModel.DesafioId);
            // verifica se  o usuário já esta na lista de ganhadores
            var ganhadorAdicionado = desafio.ListaGanhadores.FirstOrDefault(x => x.Usuario.Id == ganhadorViewModel.UsuarioGanhadorId);
            if (ganhadorAdicionado != null)
            {
                notificationList.Add("ganhador", "O ganhador selecionado já está cadastrado!");
                return await Response(null, notificationList);
            }
            // recupera a premiação
            var premiacao = _context.Premiacoes.FirstOrDefault(x => x.Id == ganhadorViewModel.PremiacaoId);
            // adiciona ganhador
            var ganhador = new Ganhador(ganhadorViewModel.Nome, ganhadorViewModel.LinkedinUrl, usuarioGanhador, premiacao, desafio);
            // adiciona no banco
            _context.Add(ganhador);
            _context.SaveChanges();

            return await Response(ganhador, notificationList);
        }
    }
}