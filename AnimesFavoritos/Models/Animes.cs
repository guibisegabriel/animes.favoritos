namespace AnimesFavoritos.Models
{
    public class Anime
    {
        public string Nome { get; set; }
        public string Sinopse { get; set; }
        public List<string> Genero{ get; set; }
        public string Duracao { get; set; }
        public string Classificacao { get; set; }
        public string Imagem { get; set; }

    

        public Anime()
        {
            Genero = new List<string>();
        }
    }
}