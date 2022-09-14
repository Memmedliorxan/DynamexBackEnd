using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Core.Entities;

namespace Business.ViewModels
{
    public class UserProfileViewModel
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public decimal TL { get; set; }
        public decimal Dollar { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime Birthday { get; set; }
        public string PassFIN { get; set; }
        public string PassNo { get; set; }

        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        public string NewPassword { get; set; }

        public List<Filial> Filials { get; set; }
        public List<City> Cities { get; set; }
        public ApplicationUser LogUser { get; set; }
        public int CityId { get; set; }
        public int FilialId { get; set; }
        public List<City> City { get; set; }
        public List<Filial> Filial { get; set; }
        public string Location { get; set; }

    }
}
