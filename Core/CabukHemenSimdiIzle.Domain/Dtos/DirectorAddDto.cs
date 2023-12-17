﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CabukHemenSimdiIzle.Domain.Dtos
{
    public class DirectorAddDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public List<Guid> MovieIds { get; set; }
    }
}
