using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ADCourseWork.Models;


namespace ADCourseWork.Services
{
    public interface ICashflows
    {
        Task SaveCashFlowAsync(CashFlow cashflow);
        Task<List<CashFlow>> LoadCashFlowAsync();
        //Task<List<CashFlow>> GetCashFlowsAsync();
    }
}
