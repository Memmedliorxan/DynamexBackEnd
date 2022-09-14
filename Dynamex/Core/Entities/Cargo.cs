using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Entities
{
    public class Cargo
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string TrackId { get; set; }
        public decimal Weight { get; set; }
        public decimal CargoPrice { get; set; }
        public decimal DeliveryPrice { get; set; }
        public string CargoCategory { get; set; }
        public string ShoppingName { get; set; }
        public bool IsAzerbaijan { get; set; }
        public bool IsTurkey { get; set; }
        public bool IsCustoms { get; set; }
        public bool IsWay { get; set; }
        public bool IsDelivery { get; set; }
        public bool IsFilial { get; set; }
        public DateTime AzerbaijanDate { get; set; }
        public DateTime TurkeyDate { get; set; }
        public DateTime CustomsDate { get; set; }
        public DateTime WayDate { get; set; }
        public DateTime DeliveryDate { get; set; }
        public DateTime FilialDate { get; set; }
        public bool IsDeleted { get; set; }
        public bool IsPay { get; set; }
        public string ApplicationUserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
    }
}
