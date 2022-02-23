using _9jasorosoke.Interface;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace _9jaSoroSoke.Domain.Models
{
    public class CompanyOwnerViewModel: ICompanyOwnerViewModel
    {
        public int Id { get; set; }

        public string PurchaseReciept { get; set; }

        [Required]
        [StringLength(250)]
        public string CompanyAddress { get; set; }
        public string ProcessingMessage { get; set; }

        [Required]
        [StringLength(150)]
        public string CompanyName { get; set; }

        [StringLength(150)]
        [Required]
        public string FuelDepotName { get; set; }

        [Required]
        [StringLength(250)]
        public string FuelDepotAddress { get; set; }

        [Required]
        [RegularExpression(@"^(\+?[0-9]+)$", ErrorMessage = "Invalid Phone Number")]
        public string CompanyPhoneNumber { get; set; }

        [Required]
        public DateTime DatePurchased { get; set; }

        public DateTime DateReported { get; set; }

        public IFormFile File { get; set; }


    }
}
