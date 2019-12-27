using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Threading.Tasks;
using BackEnd.Domain;
using BackEnd.Infra.Context;
using BackEnd.Infra.Security;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace BackEnd.Controllers
{
    public class LoginController : BaseController
    {
        private Usuario _usuario;
        private readonly TokenOptions _tokenOptions;
        private readonly GRAACCDbContext _context;
        private readonly JsonSerializerSettings _serializerSettings;

        public LoginController(IOptions<TokenOptions> jwtOptions, GRAACCDbContext context)
        {
            _tokenOptions = jwtOptions.Value;
            _context = context;
            ThrowIfInvalidOptions(_tokenOptions);

            _serializerSettings = new JsonSerializerSettings
            {
                Formatting = Formatting.Indented,
                ContractResolver = new CamelCasePropertyNamesContractResolver()
            };
        }

        [HttpPost]
        [AllowAnonymous]
        [Route("v1/login")]
        public async Task<IActionResult> Post([FromBody] string nomeUsuario, string senha)
        {
            var notificationList = new ListDictionary();
            if (string.IsNullOrEmpty(nomeUsuario) || string.IsNullOrEmpty(senha))
            {
                notificationList.Add("user", "Senha ou usuário inválido!");
                return await Response(null, notificationList);
            }

            var identity = await GetClaims(nomeUsuario, senha);
            if (identity == null)
            {
                notificationList.Add("user", "Usuário ou senha inválidos");
                return await Response(null, notificationList);
            }

            var claims = new List<Claim>()
            {
                new Claim(JwtRegisteredClaimNames.UniqueName, nomeUsuario),
                new Claim(JwtRegisteredClaimNames.Email, nomeUsuario),
                new Claim(JwtRegisteredClaimNames.Jti, await _tokenOptions.JtiGenerator()),
                new Claim(JwtRegisteredClaimNames.Iat, ToUnixEpochDate(_tokenOptions.EmitidoEm).ToString(), ClaimValueTypes.Integer64),
                new Claim(JwtRegisteredClaimNames.AuthTime, DateTime.Now.ToLongTimeString())
            };
            foreach (var item in identity.Claims)
            {
                claims.Add(item);
            }
            var jwt = new JwtSecurityToken(
                issuer: _tokenOptions.Emissor,
                audience: _tokenOptions.Publico,
                claims: claims.AsEnumerable(),
                notBefore: _tokenOptions.NaoAntes,
                expires: _tokenOptions.Expiracao,
                signingCredentials: _tokenOptions.SigningCredentials);

            var encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);

            var response = new
            {
                token = encodedJwt,
                expires = (int)_tokenOptions.ValidoPor.TotalSeconds,
                user = new
                {
                    id = _usuario.Id,
                    name = _usuario.NomeUsuario.ToString(),
                    username = _usuario.NomeUsuario,
                }
            };

            var json = JsonConvert.SerializeObject(response, _serializerSettings);

            return new OkObjectResult(json);
        }

        private Task<ClaimsIdentity> GetClaims(string nomeUsuario, string senha)
        {
            var usuario = _context.Usuarios.FirstOrDefault(x => x.NomeUsuario == nomeUsuario);

            if (usuario == null)
                return Task.FromResult<ClaimsIdentity>(null);

            if (!usuario.AutenticarUsuario(nomeUsuario, senha))
                return Task.FromResult<ClaimsIdentity>(null);

            _usuario = usuario;
            var claimsObtidas = new List<Claim>();

            var listaPermissao = new List<string>();

            // if (usuario.EhEmpresa)
            // {
            //     claimsObtidas.Add(new Claim("EmpresaId", usuario.Id.ToString()));
            // }

            claimsObtidas.Add(new Claim("UsuarioId", usuario.Id.ToString()));

            return Task.FromResult(new ClaimsIdentity(
                new GenericIdentity(usuario.NomeUsuario, "Token"),
              claimsObtidas.ToArray()));
        }
        private static void ThrowIfInvalidOptions(TokenOptions options)
        {
            if (options == null) throw new ArgumentNullException(nameof(options));

            if (options.ValidoPor <= TimeSpan.Zero)
                throw new ArgumentException("O período deve ser maior que zero", nameof(TokenOptions.ValidoPor));

            if (options.SigningCredentials == null)
                throw new ArgumentNullException(nameof(TokenOptions.SigningCredentials));

            if (options.JtiGenerator == null)
                throw new ArgumentNullException(nameof(TokenOptions.JtiGenerator));
        }
        private static long ToUnixEpochDate(DateTime date)
          => (long)Math.Round((date.ToUniversalTime() - new DateTimeOffset(1970, 1, 1, 0, 0, 0, TimeSpan.Zero)).TotalSeconds);
    }
}