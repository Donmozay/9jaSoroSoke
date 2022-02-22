using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace _9jasorosoke.Interface
{
    public interface IFuelingStationOwner
    {
        int Id { get; set; }

        [Required]
         string BusinessName { get; set; }

        [Required]
         string Location { get; set; }

        [Required]
         string NameOfDepot { get; set; }

        [Required]
         string DatePurchased { get; set; }

        [Required]
         string PurchaseReciept { get; set; }
    }
}
