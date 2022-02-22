using _9jasorosoke.Interface;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace _9jasorosoke.Repositories.Models
{
    public class FuelingStationOwner : IFuelingStationOwner
    {
        public int Id { get; set; }

        [Required]
        public string BusinessName { get; set; }

        [Required]
        public string Location { get; set; }

        [Required]
        public string NameOfDepot { get; set; }

        [Required]
        public string DatePurchased { get; set; }

        [Required]
        public string PurchaseReciept { get; set; }


    }
}
