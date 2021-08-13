using System.Collections.Generic;

namespace MyLibrary.Applications.BankOperationReader
{
    public record BankOperationRequest(string AccountName1, string AccountName2);

    public class BankOperationResponse
    {
        public decimal Account1Amount { get; set; }
        public decimal Account2Amount { get; set; }
        public decimal TotalAmount { get; set; }
    }

    public class BankOperationReaderApp
    {
        private readonly IEnumerable<IHandler> _handlers;

        public BankOperationReaderApp(IEnumerable<IHandler> handlers)
        {
            _handlers = handlers;
        }

        public BankOperationResponse Process(BankOperationRequest request)
        {
            var response = new BankOperationResponse();
            foreach (var handler in _handlers) 
                handler.Process(request, response);
            return response;
        }
    }
}
