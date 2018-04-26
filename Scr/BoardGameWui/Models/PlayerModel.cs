using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BoardGameWui.Models
{
    public class Player
    {
        [Required]
        public string Name { get; set; }
    }
}