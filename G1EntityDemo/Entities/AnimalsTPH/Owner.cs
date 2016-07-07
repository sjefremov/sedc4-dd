﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.AnimalsTPH
{
    public class Owner
    {
        public int ID { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Animal> Animals { get; set; }
    }
}
