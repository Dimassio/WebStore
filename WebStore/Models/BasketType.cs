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
        public int BasketTypeId { get; set; }  

        public Item Item { get; set; }
    }
}