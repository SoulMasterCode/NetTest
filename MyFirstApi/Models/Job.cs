using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MyFirstApi.Models
{
    public class Job
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("PerfilReference")]
        public int Perfil { get; set; }
        public virtual Perfil PerfilReference { get; set; }
        [Required]
        public string Name { get; set; }
        [DataType(DataType.DateTime)]
        public string Created { get; set; }
    }
}