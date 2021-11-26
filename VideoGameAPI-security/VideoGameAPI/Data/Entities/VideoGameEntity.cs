using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace VideoGameAPI.Data.Entities
{
    public class VideoGameEntity
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string ESRB { get; set; }
        public string Genre { get; set; }
        public DateTime? ReleaseDate { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal? Price { get; set; }
        [ForeignKey("CompanyId")]
        public virtual CompanyEntity Company { get; set; }
    }
}
