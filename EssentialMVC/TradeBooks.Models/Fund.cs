using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace TradeBooks.Models
{
    public class Fund
    {
        [Key]
        [StringLength(20)]
        public string Code { get; set; }

        [StringLength(256)]
        public string Name { get; set; }

        [Range(0, 999999.99)]
        [Column(TypeName = "decimal(18, 4)")]
        public decimal NAV { get; set; }


    }
}