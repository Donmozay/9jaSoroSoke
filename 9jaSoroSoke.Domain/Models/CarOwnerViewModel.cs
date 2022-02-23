using _9jasorosoke.Interface;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Threading.Tasks;

namespace _9jaSoroSoke.Domain.Models
{
    public class CarOwnerViewModel: ICarOwnerViewModel
    {
        public string ProcessingMessage { get; set; }
        public string ProofOfVehicleOwnerShip { get; set; }
        public string PurchaseReciept { get; set; }
        [Required]
        public IList<IFormFile> File { get; set; }
        [Required]
        [StringLength(50)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(50)]
        public string LastName { get; set; }

        [Required]
        [StringLength(200)]
        public string PurchaseLocation { get; set; }

        [Required]
        [StringLength(250)]
        public string NameOfFuelingStation { get; set; }

        [Required]
        public DateTime DatePurchased { get; set; }

        
        [Required]
        [RegularExpression(@"^(\+?[0-9]+)$", ErrorMessage = "Invalid Mobile Number")]
        public string PhoneNumber { get; set; }
        public IList<ICarOwner> carOwners { get; set; }
    }
}
