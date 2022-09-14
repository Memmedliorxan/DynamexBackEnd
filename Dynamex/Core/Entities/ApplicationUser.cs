using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Entities
{
    public class ApplicationUser : IdentityUser
    {
        public string Name { get; set; }
        public string Surname{ get; set; }
        public DateTime Birtday{ get; set; }
        public string PassportNumber { get; set; }
        public string PassportFIN { get; set; }

        public int CityId { get; set; }
        public City City { get; set; }


        public int FilialId { get; set; }
        public Filial Filial { get; set; }

        public string Location { get; set; }

        public decimal TLBalance { get; set; }
        public decimal DollarBalance { get; set; }
    }
}
