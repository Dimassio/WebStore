using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebStore.Models
{
    public enum StatusEnum
    {
        DONE,   // admin marked it as done
        IN_PROGRESS, // we 've ordered it and wait for admin
    };

    public class Order
    {
        [Key]
        public int OrderId { get; set; }

        public List<int> Items { get; set; } // todo: need it?

        public StatusEnum Status { get; set; }

        public DateTime Date { get; set; }

        public virtual ICollection<ApplicationUser> Users { get; set; }
    }
}