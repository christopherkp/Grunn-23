﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace UnderwaterBot.Modules
{
    public abstract class Entity
    {
        [Key]
        public int Id { get; set; }
    }
}