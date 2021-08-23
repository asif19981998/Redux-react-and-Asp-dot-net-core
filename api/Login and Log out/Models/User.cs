﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Login_and_Log_out.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        [JsonIgnore] public string Password { get; set; }
        public string Email { get; set; }

    }
}
