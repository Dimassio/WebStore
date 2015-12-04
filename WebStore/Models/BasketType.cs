using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebStore.Models
{
    public class BasketType
    {
        [Key]
        public int OrderId { get; set; }

        public List<Item> Items { get; set; }

        public StatusEnum Status { get; set; }

        // todo: add date of order
    }
}