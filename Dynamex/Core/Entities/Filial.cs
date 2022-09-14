using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Entities
{
    public class Filial
    {
        public int Id { get; set; }

        public List<ApplicationUser> ApplicationUsers { get; set; }

        public string Name { get; set; }
        public bool IsDeleted { get; set; }
    }
}
