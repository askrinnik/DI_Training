using System.Globalization;
using MyApps.Interfaces;

namespace MyApps
{
    public class BankApp
    {
        private readonly IRepository _repository;
        private readonly IMessageWriter _writer;

        public BankApp(IRepository repository, IMessageWriter writer)
        {
            _repository = repository;
            _writer = writer;
        }

        public void Run()
        {
            WriteAmount("Petrenko");
            WriteAmount("Sokolenko");
            WriteAmount("Petrenko");
            WriteAmount("Petrenko");
            WriteAmount("Sokolenko");
        }

        private void WriteAmount(string accountName)
        {
            var amount = _repository.GetAmount(accountName).ToString(CultureInfo.CurrentCulture);
            _writer.Write($"{accountName}: {amount}");
        }
    }
}
