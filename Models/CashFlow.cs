using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADCourseWork.Models
{
    public class CashFlow
    {
        [Key]
        //public int UserId { get; set; }

        public string TransactionName { get; set; }

        public string TransactionType { get; set; }
        // Indicates that this field is a date
       
        public DateTime FlowDate { get; set; }
        public int Amount { get; set; }
        public string TransactionTag { get; set; }
        public string CustomTag { get; set; }
        public string Note { get; set; }



    }
}
