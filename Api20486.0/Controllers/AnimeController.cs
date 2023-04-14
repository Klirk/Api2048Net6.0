using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api20486._0.Models;
using Api20486._0.Context;
using Microsoft.EntityFrameworkCore;
using Azure.Core;
using Azure;
using Microsoft.Data.SqlClient;
using System.Data.Common;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Hosting.Server;

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
        public IEnumerable<AllAnime> Get()
        {
            return _animeContext.Animes;
        }

        [HttpGet("List")]
        public IEnumerable<AnimeList> Get(int Id)
        {
            return _animeContext.AnimesList.FromSqlRaw($"UserAnimeList {Id}");
        }

        [HttpPost("Add")]
        public ActionResult AddAnime([FromBody] AddAnimes anime)
        {
            try
            {
                _animeContext.Anime.Add(anime);
                _animeContext.SaveChanges();
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.InnerException.Message);
            }
        }

        [HttpDelete("Delete")]
        public ActionResult Delete(int Id)
        {
            try
            {
                var delAnime = _animeContext.Anime.FirstOrDefault(s => s.id_anime == Id);
                if (delAnime != null)
                {
                    _animeContext.Anime.Remove(delAnime);
                    _animeContext.SaveChanges();
                    return Ok();
                }
                else { return BadRequest(); }
            }
            catch (Exception e)
            {
                return BadRequest(e.InnerException.Message);
            }
        }

    }
}
    