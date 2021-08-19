using System.Collections.Generic;
using System.Threading;
using MyApps.Interfaces;

namespace MyLibrary.BankOperationRepositories
{
    public class BankRepository: IRepository
    {
        private readonly Dictionary<string, decimal> _storage = 
            new() { { "Petrenko", 11 }, { "Sokolenko", 22 }, { "Shevchenko", 33 } };
        public decimal GetAmount(string accountName)
        {
            Thread.Sleep(1000);
            return _storage[accountName];
        }
    }
}