using CabukHemenSimdiIzle.Domain.Interfaces;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CabukHemenSimdiIzle.Domain.Entities.Identity
{
    public class Role : IdentityRole<Guid>
    {
        public const string Admin = "Admin";
        public const string Customer = "Customer";
    }
}
