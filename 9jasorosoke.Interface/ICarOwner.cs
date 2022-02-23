using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace _9jasorosoke.Interface
{
    public interface ICarOwner
    {
         int Id { get; set; }

         [Required]
         string ProofOfVehicleOwnerShip { get; set; }

         [Required]
         string PurchaseReciept { get; set; }

         DateTime DateReported { get; set; }
         IList<ICarOwner> carOwners { get; set; }

    }
}
