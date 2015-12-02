using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebShop.Models
{
    public enum StatusEnum
    {
        DONE,
        IN_PROGRESS
    };

    public class Order
    {
        [Key]
        public int OrderId { get; set; }
        public List<Item> Items { get; set; }
        public StatusEnum Status { get; set; }
        // todo: add date
    }
}