using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Huertos_Autosustentables_PI.Models
{
    public class EdicionRol
    {
        public IdentityRole Rol { get; set; }
        public IEnumerable<IdentityUser> miembros { get; set; }
        public IEnumerable<IdentityUser> noMiembros { get; set; }
    }
}
