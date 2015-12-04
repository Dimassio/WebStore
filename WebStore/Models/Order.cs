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
        NOT_READY // we haven't ordered it yet
    };

    public class Order
    {
        [Key]
        public int OrderId { get; set; }

        public List<Item> Items { get; set; }

        public StatusEnum Status { get; set; } = StatusEnum.NOT_READY;

        // todo: add date of order
    }
}