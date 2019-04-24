namespace Store.Domain.StoreContext.Services
{
    public interface IEmailServices
    {
        void Send(string to, string from, string subject, string body);
    }
}