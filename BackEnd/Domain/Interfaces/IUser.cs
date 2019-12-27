using System.Collections.Generic;
using System.Security.Claims;

namespace BackEnd.Domain.Interfaces
{
    public interface IUser
    {
        string Name { get; }
        bool IsAuthenticated();
        IEnumerable<Claim> GetClaimsIdentity();
        int GetEmpresa();
        int GetUsuarioId();
    }
}