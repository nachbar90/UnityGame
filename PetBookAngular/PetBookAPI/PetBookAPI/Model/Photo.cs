﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetBookAPI.Model
{
    public class Photo
    {
        public int Id { get; set; }
        public string Url { get; set; }
        public string Description { get; set; }
        public bool MainPhoto { get; set; }
        public Pet Pet { get; set; }
        public int PetId { get; set; }
        public string PublicId { get; set; }
    }
}
