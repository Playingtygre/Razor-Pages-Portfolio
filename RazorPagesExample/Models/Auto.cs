using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace RazorPagesExample.Models
{
    public class Auto
    {
        public long Id { get; set; }

        [Required]
        [MinLength(3)]
        public string Name { get; set; }

        [Required]
        [MinLength(3)]
        public string Summary{ get; set; }

        [Display(Name = "Image URL")]
        public string ImageUrl { get; set; }


    }
}
