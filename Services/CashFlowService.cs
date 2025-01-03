using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;
using ADCourseWork.Models;

namespace ADCourseWork.Services
{
    public class CashFlowService : ICashflows
    {
        private readonly string cashFlowFilePath = Path.Combine(AppContext.BaseDirectory, "CashFlows.json");
       
        private readonly List<CashFlow> cashFlows = new();


        

       
        public async Task SaveCashFlowAsync(CashFlow cashflow)
        {
            try
            {
                var cashFlows = await LoadCashFlowAsync(); // Load existing cashflows

                cashFlows.Add(cashflow);
                await SaveCashFlowsAsync(cashFlows); // Save the updated list
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error saving cash flow: {ex.Message}");
                throw;
            }
        }

        public async Task<List<CashFlow>> LoadCashFlowAsync()
        {
            try
            {
                if (!File.Exists(cashFlowFilePath))
                {
                    return new List<CashFlow>();
                }

                var json = await File.ReadAllTextAsync(cashFlowFilePath);
                return JsonSerializer.Deserialize<List<CashFlow>>(json) ?? new List<CashFlow>(); // Deserialize JSON
            }
            catch (JsonException jsonEx)
            {
                Console.WriteLine($"JSON deserialization error: {jsonEx.Message}");
                return new List<CashFlow>();
            }
            catch (IOException ioEx)
            {
                Console.WriteLine($"I/O error while loading cash flows: {ioEx.Message}");
                return new List<CashFlow>();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Unexpected error while loading cash flows: {ex.Message}");
                return new List<CashFlow>();
            }
        }

        private async Task SaveCashFlowsAsync(List<CashFlow> cashFlows)
        {
            try
            {
                var json = JsonSerializer.Serialize(cashFlows, new JsonSerializerOptions { WriteIndented = true });

                await File.WriteAllTextAsync(cashFlowFilePath, json);
            }
            catch (IOException ioEx)
            {
                Console.WriteLine($"I/O error while saving cash flows: {ioEx.Message}");
                throw;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Unexpected error while saving cash flows: {ex.Message}");
                throw;
            }
        }
    }
}
