using System.Collections.Generic;
using System.Threading;

namespace MyLibrary
{
    public interface IRepository
    {
        decimal GetAmount(string accountName);
    }

    public class BankRepository: IRepository
    {
        private readonly Dictionary<string, decimal> _storage = new() { { "Petrenko", 11 }, { "Sokolenko", 22 }, { "Shevchenko", 33 } };
        public decimal GetAmount(string accountName)
        {
            Thread.Sleep(1000);
            return _storage[accountName];
        }
    }


    public class CachedRepository : IRepository
    {
        private readonly IRepository _repository;

        private readonly Dictionary<string, decimal> _storage = new() ;

        public CachedRepository(IRepository repository)
        {
            _repository = repository;
        }

        public decimal GetAmount(string accountName)
        {
            if (!_storage.TryGetValue(accountName, out var value))
            {
                value = _repository.GetAmount(accountName);
                _storage[accountName] = value;
            }
            return value;
        }
    }

}
