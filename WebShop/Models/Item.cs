using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebShop.Models
{
    public class Item
    {
        public Item() { }

        public Item(string _Name, double _Price, string _Category, string _Description, bool _ForSale)
        {
            Name = _Name;
            Price = _Price;
            Category = _Category;
            Description = _Description;
            ForSale = _ForSale;
        }
        // todo: public image {get; set;}
        [Key]
        public int ItemId { get; set; }

        [Required]
        public double Price { get; set; }

        [Required]
        public string Category { get; set; }

        [Required]
        public string Name { get; set; }

        public string Description { get; set; }

        public bool ForSale { get; set; } = false;
    }
}