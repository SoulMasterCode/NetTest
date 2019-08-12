using System;
using System.Collections;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyFirstApi.Models
{
    public class Perfil
    {
        [Key]
        public int Id { get; set; }
        public String Phone { get; set; }
        [DataType(DataType.ImageUrl)]
        public String Image { get; set; }
        public RolUser Rol { get; set; }
        public User User { get; set; }

        public virtual Collection<Job> Jobs { get; set; }
    }
}