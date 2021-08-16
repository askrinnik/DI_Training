using System.Collections.Generic;
using MyApps.Interfaces;

namespace MyLibrary.BankOperationRepositories
{
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
