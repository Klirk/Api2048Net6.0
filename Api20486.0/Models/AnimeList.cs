using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Api20486._0.Models
{
    public class AnimeList
    {
            [Key]
            [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
            public int id_anime { get; set; }
            public string? Name_anime { get; set; }
            public double Rated { get; set; }
            public int Episodes { get; set; }
            public string? Name_type { get; set; }
            public string? Name_status { get; set; }
            public string? View_status { get; set; }
    }
}
