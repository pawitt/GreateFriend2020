using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace HelloMVC.Models
{
    public class Slot
    {
        public int Id  { get; set; }

        // navigation properties
        // virtual is mean enable lazy loading
        [Required]
        public virtual  Machine Machine { get; set; }
        public virtual Product Product { get; set; }

        [ForeignKey(nameof(Product))] // in case need to chane name of foreignkey
        public Guid? ProductNo { get; set; }

        public int Quantity { get; set; }
    }
}
