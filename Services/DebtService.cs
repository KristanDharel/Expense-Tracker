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
        public async Task UpdateDebtStatusAsync(Debt debt)
        {
            try
            {
                // Load the existing debts
                var debts = await LoadCashDebtAsync();

                // Find the debt with the specified ID
                var existingDebt = debts.FirstOrDefault(d => d.Id == debt.Id);

                if (existingDebt != null)
                {
                    // Update the status of the debt
                    existingDebt.DebtStatus = debt.DebtStatus;

                    // Save the updated debts back to the JSON file
                    await SaveDebtsAsync(debts);

                    // If the status is "Cleared", remove the debt from the pending debts list
                    if (debt.DebtStatus == "Cleared")
                    {
                        debts.Remove(existingDebt);
                        await SaveDebtsAsync(debts);
                    }
                }
                else
                {
                    Console.WriteLine($"Debt with ID {debt.Id} not found.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error updating debt status: {ex.Message}");
                throw;
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
