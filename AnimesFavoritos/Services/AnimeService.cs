using System.Text.Json;
using AnimesFavoritos.Models;

namespace AnimesFavoritos.Services
{
public class AnimeService : IAnimesService

    {
        public readonly IHttpContextAccessor _session;
        public readonly string AnimesFile = @"Data\Animes.json";
        public readonly string GeneroFile = @"Data\Genero.json";

        public AnimeService(IHttpContextAccessor session)
        {
            _session = session;
            PopularSessao();
        }

        public List<Anime> GetAnimes()
        {
            PopularSessao();
            var animes = JsonSerializer.Deserialize<List<Anime>>(_session.HttpContext.Session.GetString("Animes"));
            return animes;
        }

        public List<Genero> GetGeneros()
        {
            PopularSessao();
            var tipos = JsonSerializer.Deserialize<List<Genero>>(_session.HttpContext.Session.GetString("Genero"));
            return tipos;
        }

        public Anime GetAnime(string nome)
        {
        var animes = GetAnimes();
        return animes.FirstOrDefault(p => p.Nome == nome);
        }

        public AnimesDto GetAnimesDto()
        {
            var animes = new AnimesDto()
            {
                Animes = GetAnimes(),
                Generos = GetGeneros()
            };
            return animes;
        }

        public DetailsDto GetDetailedAnime(string nome)
        {       
        var animes = GetAnimes();
        var generos = GetGeneros();
        var detalhes = new DetailsDto()
        {
        Current = animes.FirstOrDefault(p => p.Nome == nome),
        Prior = animes.OrderByDescending(p => p.Nome)
                      .FirstOrDefault(p => string.Compare(p.Nome, nome) < 0),
        Next = animes.OrderBy(p => p.Nome)
                    .FirstOrDefault(p => string.Compare(p.Nome, nome) > 0),
        };
        return detalhes;
        }


        public Genero GetGenero(string Nome)
        {
            var generos = GetGeneros();
            return generos.Where(t => t.Nome == Nome).FirstOrDefault();
        }

        private void PopularSessao()
        {
            if (string.IsNullOrEmpty(_session.HttpContext.Session.GetString("Genero")))
            {
                _session.HttpContext.Session.SetString("Animes", LerArquivo(AnimesFile));
                _session.HttpContext.Session.SetString("Genero", LerArquivo(GeneroFile));
            }
        }

        private string LerArquivo(string fileName)
        {
            using (StreamReader leitor = new StreamReader(fileName))
            {
                string dados = leitor.ReadToEnd();
                return dados;
            }
        }

        public DetailsDto GetDetailedAnimes(string Nome)
        {
            throw new NotImplementedException();
        }

        public object GetDetailedAnimes(int numero)
        {
            throw new NotImplementedException();
        }
    }
}
