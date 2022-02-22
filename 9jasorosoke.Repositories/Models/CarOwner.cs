using _9jasorosoke.Interface;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace _9jasorosoke.Repositories.Models
{
    public class CarOwner: ICarOwner
    {
        public int Id { get; set; }

        [Required]
        public string ProofOfVehicleOwnerShip { get; set; }

        [Required]
        public string PurchaseReciept { get; set; }

        public DateTime DateReported { get; set; }
    }
}
