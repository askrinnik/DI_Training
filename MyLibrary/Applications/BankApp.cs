using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLibrary.Applications
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
