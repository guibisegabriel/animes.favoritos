using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AnimesFavoritos.Models
{
    public class DetailsDto
{
    public Anime Current { get; set; }
    public Anime Prior { get; set; }
    public Anime Next { get; set; }
    public Genero Genero { get; set; }
}

}

