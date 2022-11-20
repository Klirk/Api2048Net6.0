using Api20486._0.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api20486._0.Context
{
    public class AnimesContext : DbContext
    {
        public AnimesContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Anime> Animes { get; set; }
    }
}

