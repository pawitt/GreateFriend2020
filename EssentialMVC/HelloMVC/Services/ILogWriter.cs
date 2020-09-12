namespace HelloMVC.Services
{
    public interface ILogWriter
    {
        string Name { get; }
        void write(string s);
    }
}