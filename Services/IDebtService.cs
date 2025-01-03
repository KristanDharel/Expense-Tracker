using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ADCourseWork.Models;


namespace ADCourseWork.Services
{
    public interface IDebtService
    {
        Task SaveDebtFlowAsync(Debt debtFlow);

        Task<List<Debt>> LoadCashDebtAsync();
        Task<int> GetTotalDebtsAsync();
        //Task<List<Debt>> LoadDebtAsync();
    }
}
