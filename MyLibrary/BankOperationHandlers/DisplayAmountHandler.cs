using System.Globalization;
using MyApps;
using MyApps.Interfaces;

namespace MyLibrary.BankOperationHandlers
{
    public class DisplayAmountHandler : IHandler
    {
        private readonly IMessageWriter _writer;

        public DisplayAmountHandler(IMessageWriter writer)
        {
            _writer = writer;
        }

        public void Process(BankOperationRequest request, BankOperationResponse response)
        {
            _writer.Write(response.Account1Amount.ToString(CultureInfo.CurrentCulture));
            _writer.Write(response.Account2Amount.ToString(CultureInfo.CurrentCulture));
        }
    }
}