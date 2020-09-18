using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TradeBooks.Models
{
    public class Portfolio
    {
        [Key]
        [StringLength(12)]
        public string  PortfolioId { get; set; }
    }
}
