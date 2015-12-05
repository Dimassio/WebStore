using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebStore.Models
{
    public class AddEditItemModel
    {
        [Required]
        public double Price { get; set; }

        [Required]
        public int Category { get; set; }

        [Required]
        public string Name { get; set; }

        public string Description { get; set; }

        public bool ForSale { get; set; } = false;
    }
}