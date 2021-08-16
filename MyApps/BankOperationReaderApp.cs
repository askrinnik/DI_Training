using System.Collections.Generic;
using MyApps.Interfaces;

namespace MyApps
{
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
