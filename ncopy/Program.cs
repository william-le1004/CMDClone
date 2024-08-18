// See https://aka.ms/new-console-template for more information

public class Program
{
    public static void Main(string[] args)
    {
        var originFile = @"D:\Test\test.txt";
        var destFile = @"D:\Test\test-copy.txt";

        var buffer = new byte[1024];
        using var inStream = File.OpenRead(originFile);
        using var outStream = File.OpenWrite(destFile);

        var x = inStream.Read(buffer, 0, buffer.Length);

        while (x > 0)
        {
            Console.WriteLine(x.ToString());
            outStream.Write(buffer, 0, x);
            x = inStream.Read(buffer, 0, buffer.Length);
        }
    }
}