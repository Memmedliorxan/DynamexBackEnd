using System;
using System.Collections.Generic;
using System.Text;
using Core.Entities;

namespace Business.ViewModels
{
    public class UserViewModel
    {
        public List<Cargo> Cargoes { get; set; }
        public List<City> Cities { get; set; }
        public List<Filial> Filials { get; set; }
        public List<Order> Orders { get; set; }
        public List<ApplicationUser> ApplicationUsers { get; set; }
        public Addresses Addresses { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public decimal TL { get; set; }
        public decimal Dollar { get; set; }
    }
}
