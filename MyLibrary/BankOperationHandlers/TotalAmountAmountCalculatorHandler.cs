using System.Globalization;
using MyApps;
using MyApps.Interfaces;

namespace MyLibrary.BankOperationHandlers
{
    public class TotalAmountAmountCalculatorHandler : IHandler
    {
        private readonly IMessageWriter _writer;

        public TotalAmountAmountCalculatorHandler(IMessageWriter writer)
        {
            _writer = writer;
        }

        public void Process(BankOperationRequest request, BankOperationResponse response)
        {
            response.TotalAmount = response.Account1Amount + response.Account2Amount;
            _writer.Write("Total Amount: " + response.TotalAmount.ToString(CultureInfo.CurrentCulture));
        }
    }
}
