using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace HelloMVC.Models
{
    [Table("tb_product", Schema ="sell")]
    public class Product
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        [Required]
        [StringLength(100)]
        [Remote("ValidateName","Products")]
        public string Name { get; set; }

        [Range(0,999999)]
        public decimal Price { get; set; }

        //[Column("URL")]
        [StringLength(256)]
        public string ImageUrl { get; set; }

        public string Comment { get; set; }
    }
}
