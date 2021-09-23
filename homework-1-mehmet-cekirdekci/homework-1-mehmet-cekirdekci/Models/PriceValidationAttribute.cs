using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace homework_1_mehmet_cekirdekci.Models
{
    public class PriceValidationAttribute : ValidationAttribute
    {
        public int MinPrice { get; }

        public PriceValidationAttribute(int minPrice)
        {
            MinPrice = minPrice;
        }
        public override bool IsValid(object value)
        {
            var price = Convert.ToInt32(value);

            if (price > MinPrice)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var car = validationContext.ObjectInstance as AddCarDTO;

            return base.IsValid(value, validationContext);
        }
    }
}
