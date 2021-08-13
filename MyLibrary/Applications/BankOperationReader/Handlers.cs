using System.Globalization;

namespace MyLibrary.Applications.BankOperationReader
{
    public interface IHandler
    {
        void Process(BankOperationRequest request, BankOperationResponse response);
    }

    public class ReadAmountHandler : IHandler
    {
        private readonly IRepository _repository;

        public ReadAmountHandler(IRepository repository)
        {
            _repository = repository;
        }

        public void Process(BankOperationRequest request, BankOperationResponse response)
        {
            response.Account1Amount = _repository.GetAmount(request.AccountName1);
            response.Account2Amount = _repository.GetAmount(request.AccountName2);
        }
    }

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
