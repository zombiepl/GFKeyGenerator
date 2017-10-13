namespace GKKeyGenerator.Interfaces.Options
{
    public interface IOptions
    {
        string Subject { get; set; }
        string Host { get; set; }
        string Body { get; set; }
        int Port { get; set; }
    }
}