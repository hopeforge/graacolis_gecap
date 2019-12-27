using System;
using System.Threading.Tasks;
using Microsoft.IdentityModel.Tokens;

namespace BackEnd.Infra.Security
{
    public class TokenOptions
    {
        public string Emissor { get; set; }

        public string Assunto { get; set; }

        public string Publico { get; set; }

        public DateTime NaoAntes { get; set; } = DateTime.UtcNow;

        public DateTime EmitidoEm { get; set; } = DateTime.UtcNow;

        public TimeSpan ValidoPor { get; set; } = TimeSpan.FromHours(10);

        public DateTime Expiracao => EmitidoEm.Add(ValidoPor);

        public Func<Task<string>> JtiGenerator =>
          () => Task.FromResult(Guid.NewGuid().ToString());

        public SigningCredentials SigningCredentials { get; set; }
    }
}
