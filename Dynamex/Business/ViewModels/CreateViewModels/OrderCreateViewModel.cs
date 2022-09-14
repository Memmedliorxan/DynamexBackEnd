using System;
using System.Collections.Generic;
using System.Text;
using Core.Entities;

namespace Business.ViewModels.CreateViewModels
{
    public class OrderCreateViewModel
    {
        public string Detall { get; set; }
        public string Link { get; set; }
        public int Count { get; set; }
        public decimal Price { get; set; }
        public decimal CargoPrice { get; set; }
        public string Color { get; set; }
        public string Size { get; set; }
        public string ApplicationUserId { get; set; }
        public List<ApplicationUser> ApplicationUsers { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public decimal TL { get; set; }
        public decimal Dollar { get; set; }
    }
}
