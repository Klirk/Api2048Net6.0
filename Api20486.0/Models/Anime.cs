using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Api20486._0.Models
{
    [Table("AllAnime")]
    public class Anime
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id_anime { get; set; }
        public string? Name_anime { get; set; }
        public double Rated { get; set; }
        public int Episodes { get; set; }
        public DateTime Date_start { get; set; }
        public DateTime? Date_end { get; set; }
        public string? Name_type { get; set; }
        public string? Name_rating { get; set; }
        public string? Name_status { get; set; }
        public string? Name_season { get; set; }
        public string? Genere_list { get; set; }

    }
}