using System.Collections.Generic;
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
    public class UsuarioController : BaseController
    {
        private readonly GRAACCDbContext _context;
        public UsuarioController(GRAACCDbContext gRAACCDbContext)
        {
            _context = gRAACCDbContext;
        }

        [HttpPost]
        [AllowAnonymous]
        [Route("v1/usuario/add")]
        public async Task<IActionResult> Post([FromBody] UsuarioViewModel usuarioViewModel)
        {
            // cria lista de notificações
            var notificationList = new ListDictionary();
            // verifica se as classes estão nulas
            if (usuarioViewModel == null)
            {
                notificationList.Add("object", "O objeto enviado está nulo!");
                return await Response(null, notificationList);
            }
            // verifica se o usuário existe no banco
            Usuario usuario = _context.Usuarios.FirstOrDefault(x => x.NomeUsuario == usuarioViewModel.Nome);
            if (usuario != null)
            {
                notificationList.Add("object", "O usuário já está cadastrado!");
                return await Response(null, notificationList);
            }
            // cria o usuário
            usuario = new Usuario(usuarioViewModel.Nome, usuarioViewModel.Senha);
            // adiciona no banco
            _context.Add(usuario);
            _context.SaveChanges();

            return await Response(usuario, notificationList);
        }

        // [HttpGet]
        // [AllowAnonymous]
        // [Route("v1/desafio/usuario/{id:int}")]
        // public IActionResult Get(int usuarioId)
        // {
        //     return Ok(_context.DesafioUsuario.Include(x => x.Usuario).Include(x => x.Desafio).Where(x => x.UsuarioId == usuarioId).ToList());
        // }

        [HttpGet]
        [AllowAnonymous]
        [Route("v1/usuario/getList")]
        public IActionResult GetListUsuarios()
        {
            var listaUsuarios = _context.Usuarios.ToList();
            if (!listaUsuarios.Any())
            {
                listaUsuarios = new List<Usuario>();
                listaUsuarios.Add(new Usuario("eurohack@live.com", "teste@123"));
                listaUsuarios.Add(new Usuario("kourai@outlook.com", "teste@123"));
                listaUsuarios.Add(new Usuario("breegster@icloud.com", "teste@123"));
                listaUsuarios.Add(new Usuario("rhialto@msn.com", "teste@123"));
                listaUsuarios.Add(new Usuario("thassine@optonline.net", "teste@123"));
                listaUsuarios.Add(new Usuario("nichoj@hotmail.com", "teste@123"));
                listaUsuarios.Add(new Usuario("budinger@aol.com", "teste@123"));
                listaUsuarios.Add(new Usuario("marnanel@optonline.net", "teste@123"));
                listaUsuarios.Add(new Usuario("oevans@yahoo.com", "teste@123"));
                listaUsuarios.Add(new Usuario("choset@att.net", "teste@123"));
                _context.AddRange(listaUsuarios);
                _context.SaveChanges();
            }
            return Ok(listaUsuarios);
        }

    }
}