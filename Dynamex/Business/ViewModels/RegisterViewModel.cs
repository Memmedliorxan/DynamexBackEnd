using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Core.Entities;

namespace Business.ViewModels
{
    public class RegisterViewModel
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string PhoneNum { get; set; }
        public DateTime BirthDay { get; set; }
        public string PassportNumber { get; set; }
        public string PassportFin { get; set; }
        public string Location { get; set; }


        public int CityId { get; set; }
        public int FilialId { get; set; }
        public List<City> City { get; set; }
        public List<Filial> Filial { get; set; }

        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Compare("Password")]
        public string PasswordConfirm { get; set; }
    }
}
