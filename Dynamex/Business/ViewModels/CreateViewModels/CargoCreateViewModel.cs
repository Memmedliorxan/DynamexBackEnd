using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ViewModels.CreateViewModels
{
   public  class CargoCreateViewModel
    {
        public string Name { get; set; }
        public string TrackId { get; set; }
        public decimal Weight { get; set; }
        public decimal CargoPrice { get; set; }
        public decimal DeliveryPrice { get; set; }
        public string CargoCategory { get; set; }
        public string ShoppingName { get; set; }
        public string ApplicationUserId { get; set; }
    }
}
