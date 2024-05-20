using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sabio.Models.Requests
{
    public class CheckoutAddRequest
    {
        [Required]
        public string Image { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public decimal Total { get; set; }

    }
}
