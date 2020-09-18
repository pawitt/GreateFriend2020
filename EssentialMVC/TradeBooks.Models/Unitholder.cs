using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TradeBooks.Models
{
    public class UnitHolder
    {
        [Key]
        [Required]
        [StringLength(12)]
        public string UnitHolderId { get; set; }

        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public Guid UserId { get; set; }

        [StringLength(100)]
        public string FirstName { get; set; }

        [StringLength(100)]
        public string LastName { get; set; }

        [StringLength(100)]
        public string Title { get; set; }

        [StringLength(20)]
        public Gender Gender { get; set; } = Gender.NotKnow;

        public DateTime CreatedDateUtc { get; set; } = DateTime.UtcNow;
        public DateTime? LastLoginDateUtc { get; set; } = null;

        public virtual ICollection<Subscription> Subscriptions { get; set; }
         = new HashSet<Subscription>();

    }
}