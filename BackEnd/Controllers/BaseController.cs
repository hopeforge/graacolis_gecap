using System;
using System.Collections.Specialized;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Internal;
namespace BackEnd.Controllers
{
    public class BaseController : Controller
    {
        public async Task<IActionResult> Response(object result, ListDictionary notifications)
        {
            if (!notifications.Any())
            {
                try
                {
                    return Ok(new
                    {
                        success = true,
                        data = result
                    });
                }
                catch (Exception ex)
                {
                    var mensagem = ex.Message;
                    var inner = ex.InnerException.Message;
                    object[] er = { "Ocorreu uma falha interna no servidor.", ex.Message, ex };
                    return base.BadRequest(new
                    {
                        success = false,
                        errors = er
                    });
                }
            }
            else
            {
                return BadRequest(new
                {
                    success = false,
                    errors = notifications
                });
            }
        }
    }
}