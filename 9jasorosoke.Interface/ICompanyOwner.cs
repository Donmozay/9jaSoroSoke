using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace _9jasorosoke.Interface
{
    public interface ICompanyOwner
    {

         int Id { get; set; }

         string PurchaseReciept { get; set; }

        [Required]
        [StringLength(250)]
         string CompanyAddress { get; set; }

        [Required]
        [StringLength(150)]
         string CompanyName { get; set; }

        [StringLength(150)]
        [Required]
         string FuelDepotName { get; set; }

        [Required]
        [StringLength(250)]
         string FuelDepotAddress { get; set; }

        [Required]
        [RegularExpression(@"^(\+?[0-9]+)$", ErrorMessage = "Invalid Phone Number")]
         string CompanyPhoneNumber { get; set; }

        [Required]
         DateTime DatePurchased { get; set; }

         DateTime DateReported { get; set; }

         IList<ICompanyOwner> companyOwners { get; set; }
    }
}
