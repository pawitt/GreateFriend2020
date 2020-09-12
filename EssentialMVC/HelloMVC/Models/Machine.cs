using Microsoft.AspNetCore.Mvc.ApplicationModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace HelloMVC.Models
{
    public class Machine
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [Column(TypeName ="decimal(18,4)")]
        public decimal Total { get; private set; }

        [NotMapped]
        public double Percentage { get; set; }

        public MachineStatus Status { get; set; } = MachineStatus.Off;
        
        public Machine()
        {           
        }

        public virtual ICollection<Slot> Slots { get; set; } = new HashSet<Slot>();

        public bool AcceptsCoin(decimal amount)
        {
            if (Status == MachineStatus.Off)
                return false;
            if (amount == 1) {
                var ex = new Exception("We cannot accept this coin");
                throw ex;
            }

            Total += amount;
            return true;           
        }

        public void TurnOn()
        {
            Status = MachineStatus.On;           
        }

        public void TurnOff()
        {
            Total = 0m;
            Status = MachineStatus.Off;
        }

        public decimal ReturnRemainingCoin()
        {
            decimal remainingCoin = Total;
            Total = 0;
            return remainingCoin;
        }
    }
}
