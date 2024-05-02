using System.ComponentModel.DataAnnotations;

namespace DemoApplicationWeb.Models
{
    public class Blog
    {
        [Key]
        public int id { get; set; }
        [Required]
        public string name { get; set; }
        [Required]
        public string Content { get; set; }
        [Required]
        public DateTime createdOn { get; set; } = DateTime.Now;
    }
}
