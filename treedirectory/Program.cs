// See https://aka.ms/new-console-template for more information

public class Program
{
    public static void Main(string[] args)
    {
        var originFile = @"D:\Test\";
        var directory = new DirectoryInfo(originFile);
        var items = SearchDirectory(directory);
        foreach (var item in items)
            Console.WriteLine($"{string.Concat(Enumerable.Repeat('\t', item.Deepth)) + item.Name}");
    }

    /// <summary>
    /// Recursively searches through a directory and its subdirectories, yielding hierarchical items that represent the directory structure.
    /// </summary>
    /// <param name="directory">The root directory to start the search from.</param>
    /// <param name="deep">The current depth level in the directory hierarchy, starting from 0 for the root directory.</param>
    /// <returns>An enumerable collection of HierarchicalItem objects representing the directory and file structure.</returns>
    static IEnumerable<HierarchicalItem> SearchDirectory(DirectoryInfo directory, int deep = 0)
    {
        // Yield the current directory as a HierarchicalItem
        yield return new HierarchicalItem(directory.Name, deep);

        // Recursively call SearchDirectory for each subdirectory, increasing the depth by 1
        foreach (var subdirectory in directory.GetDirectories())
        foreach (var item in SearchDirectory(subdirectory, deep + 1))
            yield return item;

        // Yield each file in the current directory as a HierarchicalItem, with an incremented depth
        foreach (var file in directory.GetFiles())
            yield return new HierarchicalItem(file.Name, deep + 1);
    }

    public class HierarchicalItem
    {
        public string Name { get; }
        public int Deepth { get; }

        public HierarchicalItem(string name, int deepth)
        {
            Name = name;
            Deepth = deepth;
        }
    }
}