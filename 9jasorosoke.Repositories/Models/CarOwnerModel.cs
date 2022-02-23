using _9jasorosoke.Interface;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace _9jasorosoke.Repositories.Models
{
    public class CarOwnerModel: ICarOwner
    {
        public int Id { get; set; }

        [Required]
        public string ProofOfVehicleOwnerShip { get; set; }

        [Required]
        public string PurchaseReciept { get; set; }

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

        public DateTime DateReported { get; set; }

        [Required]
        [RegularExpression(@"^(\+?[0-9]+)$", ErrorMessage = "Invalid Mobile Number")]
        public string PhoneNumber { get; set; }

        public IList<ICarOwner> carOwners { get; set; }

    }
}
