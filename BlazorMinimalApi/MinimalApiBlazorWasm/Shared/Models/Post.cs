using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Shared.Models
{
    public class Post
    {
        [Key]
        public int PostId {get; set;}
        [Required]
        [MaxLength(100)]
        public string Title {get; set;} = string.Empty;
         [Required]
        [MaxLength(1000)]
        public string Content {get; set;} = string.Empty;
    }
}