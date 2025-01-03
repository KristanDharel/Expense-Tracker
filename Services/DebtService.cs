using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;
using ADCourseWork.Models;

namespace ADCourseWork.Services
{
    public class DebtService : IDebtService
    {

        private readonly string debtFilePath = Path.Combine(AppContext.BaseDirectory, "Debts.json");
        public async Task<int> GetTotalDebtsAsync()
        {
            var debts = await LoadCashDebtAsync();
            return debts.Sum(debt => debt.Amount);
        }

        public async Task SaveDebtFlowAsync(Debt debtFlow)
        {
            try
            {
                var debts = await LoadCashDebtAsync(); // Load existing debts

                debts.Add(debtFlow);
                await SaveDebtsAsync(debts); // Save the updated list
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error saving debt flow: {ex.Message}");
                throw;
            }
        }

        public async Task<List<Debt>> LoadCashDebtAsync()
        {
            try
            {
                if (!File.Exists(debtFilePath))
                {
                    return new List<Debt>();
                }

                var json = await File.ReadAllTextAsync(debtFilePath);
                return JsonSerializer.Deserialize<List<Debt>>(json) ?? new List<Debt>(); // Deserialize JSON
            }
            catch (JsonException jsonEx)
            {
                Console.WriteLine($"JSON deserialization error: {jsonEx.Message}");
                return new List<Debt>();
            }
            catch (IOException ioEx)
            {
                Console.WriteLine($"I/O error while loading debts: {ioEx.Message}");
                return new List<Debt>();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Unexpected error while loading debts: {ex.Message}");
                return new List<Debt>();
            }
        }

        private async Task SaveDebtsAsync(List<Debt> debts)
        {
            try
            {
                var json = JsonSerializer.Serialize(debts, new JsonSerializerOptions { WriteIndented = true });

                await File.WriteAllTextAsync(debtFilePath, json);
            }
            catch (IOException ioEx)
            {
                Console.WriteLine($"I/O error while saving debts: {ioEx.Message}");
                throw;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Unexpected error while saving debts: {ex.Message}");
                throw;
            }
        }
    }
}
