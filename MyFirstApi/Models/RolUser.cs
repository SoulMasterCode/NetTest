using System.ComponentModel.DataAnnotations;

namespace MyFirstApi.Models
{
    public class RolUser
    {
        [Key]
        public int Id { get; set; }
        public string RolName { get; set; }
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }

        public override string ToString()
        {
            return this.RolName;
        }
    }
}