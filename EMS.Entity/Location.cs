﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMS.Entity
{
    public class Location
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Event> Events { get; set; }
    }
}