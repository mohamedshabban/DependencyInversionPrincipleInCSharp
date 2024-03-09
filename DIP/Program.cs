namespace DIP
{
    /// <summary>
    /// The Dependency Inversion Principle (DIP) is one of the SOLID principles,
    /// and it suggests that high-level modules should not 
    /// depend on low-level modules, but both should depend on abstractions. Additionally, 
    /// abstractions should not depend on details; details should depend on abstractions.
    /// </summary>

    // Abstraction for the low-level module
    public interface IMessageSender
    {
        void Send(string message);
    }
    //// Low-level module implementing the abstraction
    public class SMSSender : IMessageSender
    {
        public void Send(string message)
        {
            Console.WriteLine(message + " via SMS");
        }
    }
    //// Another low-level module implementing the abstraction
    public class EmailSender : IMessageSender
    {
        public void Send(string message)
        {
            Console.WriteLine(message + " via Email");
        }
    }
    //// High-level module depending on the abstraction
    public class Notification
    {
        private readonly IMessageSender _sender;
        public Notification(IMessageSender sender)
        {
            _sender = sender;
        }

        public void Notify(string message)
        {
            _sender.Send(message);
        }
    }
    class Program
    {
        static void Main()
        {
            Notification notification = new Notification(new SMSSender());
            notification.Notify("Hello");

            notification = new Notification(new EmailSender());
            notification.Notify("Hello");
        }
    }

}