using MyApps;
using MyApps.Interfaces;

namespace MyLibrary.BankOperationHandlers
{
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
}