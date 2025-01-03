using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADCourseWork.Models
{
    public class Debt
    {
        [Key]
        //public int UserId { get; set; }

        public string Title { get; set; }

        public int Amount { get; set; }

        public DateTime TransactionDate { get; set; }
        public DateTime DueDate { get; set; }
        public string DebtTransactionTag { get; set; }
        public string DebtCustomTag { get; set; }
        public string DebtNote { get; set; }



    }
}
