using System.Collections.Generic;
using System.Security.Claims;
using Microsoft.AspNetCore.Http;
using System.Linq;
using System;
using BackEnd.Domain.Interfaces;

namespace BackEnd.Domain
{
    public class AspNetUser : IUser
    {
        private readonly IHttpContextAccessor _accessor;
        public AspNetUser(IHttpContextAccessor accessor)
        {
            _accessor = accessor;
        }
        public string Name => _accessor.HttpContext.User.Identity.Name;

        public IEnumerable<Claim> GetClaimsIdentity()
        {
            return _accessor.HttpContext.User.Claims;
        }

        public bool IsAuthenticated()
        {
            return _accessor.HttpContext.User.Identity.IsAuthenticated;
        }

        public int GetEmpresaId()
        {
            var claim = _accessor.HttpContext.User.Claims.FirstOrDefault(c => c.Type == "Empresa");
            if (claim != null)
            {
                var claimValue = claim.Value;
                var empresaId = Int32.Parse(claim.Value);
                return empresaId;
            }
            return 0;
        }

        public int GetUsuarioId()
        {
            var claim = _accessor.HttpContext.User.Claims.FirstOrDefault(c => c.Type == "UsuarioId");
            if (claim != null)
            {
                var claimValue = claim.Value;
                var usuarioId = Int32.Parse(claim.Value);
                return usuarioId;
            }
            return 0;
        }

        public int GetEmpresa()
        {
            throw new NotImplementedException();
        }
    }
}
