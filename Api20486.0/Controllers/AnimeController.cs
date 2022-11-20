using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api20486._0.Models;
using Api20486._0.Context;

namespace Api20486._0.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnimeController : ControllerBase
    {
        private AnimesContext _animeContext;
        public AnimeController(AnimesContext animeContext)
        {
            _animeContext = animeContext;
        }

        // GET: api/<GenreController>
        [HttpGet]
        public IEnumerable<Anime> Get()
        {
            return _animeContext.Animes;
        }
    }
}
    