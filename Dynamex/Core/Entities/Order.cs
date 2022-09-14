using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Core.Entities
{
    public class Order
    {
        public int Id { get; set; }
        public string Detall { get; set; }
        public string Link { get; set; }
        //public string Category { get; set; }
        public int Count { get; set; }
        public decimal Price { get; set; }
        public decimal CargoPrice { get; set; }
        public string Color { get; set; }
        public string Size { get; set; }
        //public string Ss { get; set; }
        //[NotMapped]
        //public IFormFile Photo { get; set; }
        public bool IsOrder { get; set; }
        public DateTime Date { get; set; }
        public string ApplicationUserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
    }
}
