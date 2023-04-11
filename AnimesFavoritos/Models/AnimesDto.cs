using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AnimesFavoritos.Models
{
    public class AnimesDto
    {
        public List<Genero> Generos {get; set; }
        public List<Anime> Animes {get; set; }   
    }
}