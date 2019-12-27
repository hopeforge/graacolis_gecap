namespace BackEnd.Domain
{
    public class Badge
    {
        protected Badge()
        {
        }
        public Badge(string imgURL, string token, Usuario usuario, Desafio desafio)
        {
            ImgURL = imgURL;
            Token = token;
            Usuario = usuario;
            Desafio = desafio;
        }

        public int Id { get; set; }
        public string ImgURL { get; set; }
        public string Token { get; set; }
        public Usuario Usuario { get; set; }
        public Desafio Desafio { get; set; }
    }
}