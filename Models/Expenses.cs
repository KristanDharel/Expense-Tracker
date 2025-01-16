﻿namespace ADCourseWork.Models
{
    public class Expense
    {
        public string ExpenseId { get; set; }
        public string Description { get; set; }
        public decimal Amount { get; set; }
        public DateTime Date { get; set; }
        public string UserId { get; set; }
    }
}
