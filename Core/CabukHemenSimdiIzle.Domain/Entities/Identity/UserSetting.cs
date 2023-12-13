﻿using CabukHemenSimdiIzle.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CabukHemenSimdiIzle.Domain.Entities.Identity
{
    public class UserSetting : EntityBase<Guid>
    {
        public Guid UserId { get; set; }
        public User User { get; set; }
        public Int16 TimeZone { get; set; }
        public string LanguageCode { get; set; }
    }
}
