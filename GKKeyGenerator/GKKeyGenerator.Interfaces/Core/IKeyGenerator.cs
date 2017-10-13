namespace GKKeyGenerator.Interfaces.Core
{
    public interface IKeyGenerator
    {
        string NIP { get; set; }
        string Product { get; set; }
        string ProductModule { get; set; }
        int NumberOfModule { get; set; }
    }
}