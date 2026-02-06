namespace Assignment_3.Services
{
    public class MessageService : IMessageService
    {
        public string GetMessage()
        {
            return "Message from Custom Service (Dependency Injection)";
        }
    }
}
