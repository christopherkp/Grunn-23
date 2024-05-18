using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace UnderwaterBot.Modules
{
        // Model for fish
        public class Fish : Entity
        {
            [Key]
            public int Id { get; set; }
            public string Fishes { get; set; }
            public string Rarity { get; set; }

       
    }
}


