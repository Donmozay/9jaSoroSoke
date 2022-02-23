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
        [Required]
        [StringLength(50)]
         string FirstName { get; set; }

        [Required]
        [StringLength(50)]
         string LastName { get; set; }

        [Required]
        [StringLength(200)]
         string PurchaseLocation { get; set; }

        [Required]
        [StringLength(250)]
         string NameOfFuelingStation { get; set; }

        [Required]
         DateTime DatePurchased { get; set; }

        [Required]
        [RegularExpression(@"^(\+?[0-9]+)$", ErrorMessage = "Invalid Mobile Number")]
         string PhoneNumber { get; set; }
        IList<ICarOwner> carOwners { get; set; }

    }
}
