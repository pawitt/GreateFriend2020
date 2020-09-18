
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace TradeBooks.Models
{
    public class Subscription
    {

        public int SubscriptionId { get; set; }

        public DateTime DateUtc { get; set; }

        [Required]
        public virtual Fund Fund { get; set; }

        [Required]
        public virtual UnitHolder Owner { get; set; }

        [ForeignKey(nameof(Owner))]
        public string OwnerId { get; set; }

        public decimal Amount { get; set; }

        // 
        public decimal? AllocNAV { get; set; }
        public decimal? AllocUnits { get; set; }

    }
}