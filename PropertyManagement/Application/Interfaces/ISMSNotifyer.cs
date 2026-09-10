namespace PropertyManagement.Application.Interfaces
{
    public interface ISMSNotifyer
    {
        Task Notify(string message);
    }
}
