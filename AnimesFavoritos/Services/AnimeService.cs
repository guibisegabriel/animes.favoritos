using System.Text.Json;
using Animes.Models;

namespace Pokedex.Services;
public class AnimeService : IanimesService
{
    public readonly IHttpContextAccessor _session;
    public readonly string AnimesFile = @"Data\Animes.json";
    public readonly string GeneroFile = @"Data\Genero.json";
    public AnimesService(IHttpContextAccessor session)
{
    _session = session;
    PopularSessao();
}
    public List<anime> GetAnimes()
    {
        {
            PopularSessao();
            var animes = JsonSerializer.Deserialize<List<Anime>>
            (_session.HttpContext.Session.GetString("Animes"));
            return Animes;
        }
    }

    public List<Genero> GetGeneros()
{
PopularSessao();
var tipos = JsonSerializer.Deserialize<List<Tipo>>
(_session.HttpContext.Session.GetString("Tipos"));
return tipos;
}
public Pokemon GetPokemon(int Numero)
{
var pokemons = GetPokemons();
return pokemons.Where(p => p.Numero == Numero).FirstOrDefault();
}
public AnimesDto GetPokedexDto()
{
    var pokes = new PokedexDto()
{
    Pokemons = GetPokemons(),
    Tipos = GetTipos()
};
return pokes;
}public DetailsDto GetDetailedAnime(int Numero)
{
    var Animes = GetAnimes();
    var poke = new DetailsDto()
{
    Current = Animes.Where(p => p.Numero == Numero)
    .FirstOrDefault(),
    Prior = Animes.OrderByDescending(p => p.Numero)
    .FirstOrDefault(p => p.Numero < Numero),
    Next = Animes.OrderBy(p => p.Numero)
    .FirstOrDefault(p => p.Numero > Numero),
    };
    return poke;
}
public Genero GetGenero(string Nome)
{
    var Genero = GetGenero();
    return Genero.Where(t => t.Nome == Nome).FirstOrDefault();
}
private void PopularSessao()
{
    if (string.IsNullOrEmpty(_session.HttpContext.Session.GetString("Genero")))
    {
    _session.HttpContext.Session
    .SetString("Animes", LerArquivo(AnimesFile));
    _session.HttpContext.Session
    .SetString("Genero", LerArquivo(GeneroFile));
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
}