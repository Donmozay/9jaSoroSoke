using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Threading.Tasks;

namespace _9jasorosoke.Interface
{
    public interface ICarOwnerViewModel
    {
        string ProcessingMessage { get; set; }
        string ProofOfVehicleOwnerShip { get; set; }
         string PurchaseReciept { get; set; }
        [Required]
        IList<IFormFile> File { get; set; }
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
