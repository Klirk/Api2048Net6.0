using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Api20486._0.Models
{
    [Table("Anime")]
    public class Anime
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id_anime { get; set; }
        public string? Name_anime { get; set; }
        public double Rated { get; set; }
        public int Episodes { get; set; }
        public DateTime Date_start { get; set; }
        public DateTime? Date_end { get; set; }
        public int Id_type { get; set; }
        public int Id_rating { get; set; }
        public int Id_status { get; set; }
        public int Id_season { get; set; }

    }
}