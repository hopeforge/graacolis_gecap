
namespace BackEnd.Domain
{
    public class DesafioUsuario
    {
        protected DesafioUsuario()
        {
            
        }
        public int DesafioId { get; set; }
        public Desafio Desafio { get; set; }
        public int UsuarioId { get; set; }
        public Usuario Usuario { get; set; }
    }
}
