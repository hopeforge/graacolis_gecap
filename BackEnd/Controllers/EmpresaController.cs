using System.Collections.Specialized;
using System.Linq;
using System.Threading.Tasks;
using BackEnd.Domain;
using BackEnd.Domain.Interfaces;
using BackEnd.Infra.Context;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
namespace BackEnd.Controllers
{
    public class EmpresaController : BaseController
    {

        private readonly GRAACCDbContext _context;
        private readonly IUser _user;
        public EmpresaController(GRAACCDbContext context, IUser user)
        {
            _context = context;
            _user = user;
        }

        [HttpPost]
        [AllowAnonymous]
        [Route("v1/empresa/add")]
        public async Task<IActionResult> Post([FromBody] EmpresaViewModel empresaViewModel)
        {
            // cria lista de notificações
            var notificationList = new ListDictionary();

            // verifica se as classes estão nulas
            if (empresaViewModel == null)
            {
                notificationList.Add("object", "O objeto enviado está nulo!");
                return await Response(null, notificationList);
            }
            // verifica se a empresa está cadastrada
            Empresa empresa;
            empresa = _context.Empresas.FirstOrDefault(x => x.CNPJ == empresaViewModel.CNPJ);
            if (empresa != null)
            {
                notificationList.Add("empresa", "A empresa já esta cadastrada!");
                return await Response(null, notificationList);
            }
            // adiciona nova empresa
            empresa = new Empresa(empresaViewModel.NomeEmpresa, empresaViewModel.CNPJ, empresaViewModel.NomeUsuario, empresaViewModel.Senha);
            // adiciona no banco
            _context.Add(empresa);
            _context.SaveChanges();

            return await Response(empresa, notificationList);
        }


        [HttpGet]
        [AllowAnonymous]
        [Route("v1/empresa/getList")]
        public IActionResult Get()
        {
            return Ok(_context.Empresas.ToList());
        }
    }
}