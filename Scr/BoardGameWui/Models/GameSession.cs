using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BoardGameWui.Models
{
    public class GameSession
    {
        [Required]
        public string PlayerName { get; set; }

        public string OpponentName { get; set; }

        public bool MyTurn { get; set; }
    }
}