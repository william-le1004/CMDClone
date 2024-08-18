
public class Program
{
    public static void Main(string[] args)
    {
        var path = Console.ReadLine() + ":\\";
        var dir = new DirectoryInfo(path);
        var directories = dir.GetDirectories();
        foreach (var directory in directories)
        {
            Console.WriteLine($"{directory.LastWriteTime:MM/dd/yyyy}  {directory.Name}  {directory.CreationTime:hh:mm}");
        }
    }
}