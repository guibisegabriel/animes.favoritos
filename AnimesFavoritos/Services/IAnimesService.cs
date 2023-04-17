using AnimesFavoritos.Models;
namespace AnimesFavoritos.Services;

public interface IAnimesService
{
      List<Anime> GetAnimes();
      List<Genero> GetGeneros();
      Anime GetAnime(string Nome);
      AnimesDto GetAnimesDto();
      DetailsDto GetDetailedAnimes(string Nome);
      Genero GetGenero(string Genero);
}
