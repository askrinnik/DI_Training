namespace MyApps.Interfaces
{
    public interface IHandler
    {
        void Process(BankOperationRequest request, BankOperationResponse response);
    }
}