using System.IO.Pipes;

internal class Program
{
    public static int answer = 0;
    public static List<TreeNode> highestDirs = new List<TreeNode>();
    private static void Main(string[] args)
    {
        string[] lines = File.ReadAllLines(@"c:\src\AOC\AOCDay7\input.txt");
        TreeNode root = new TreeNode("root", FileType.Directory, null);
        TreeNode CurNode = root;

        foreach (string line in lines)
        {
            // Change Directory
            if (line.StartsWith("$ cd "))
            {
                string directory = line.Substring(5);
                if (directory == "/")
                    CurNode = root;
                else if (directory == "..")
                {
                    CurNode = CurNode.Parent;
                }
                else
                {
                    TreeNode child = CurNode.GetChildNode(directory);
                    if (child == null)
                    {
                        child = new TreeNode(directory, FileType.Directory, CurNode);
                        CurNode.Children.Add(child);
                    }

                    CurNode = child;
                }
            }
            else if (line.StartsWith("$ ls"))
            {
                continue;
            }
            else if (line.StartsWith("dir "))
            {
                string directory = line.Substring(4);
                CurNode.Children.Add(new TreeNode(directory, FileType.Directory, CurNode));
            }
            else
            {
                string[] fileParts = line.Split(" ");
                int fileSize = int.Parse(fileParts[0]);
                string fileName = fileParts[1];
                TreeNode child = CurNode.GetChildNode(fileName);

                if (child == null)
                {
                    child = new TreeNode(fileName, FileType.File, CurNode, fileSize);
                    CurNode.Children.Add(child);
                }
            }
        }

        Console.WriteLine(UpdateFileSizes(root));
        Console.WriteLine(answer);
        FindLowestFileSize();
    }

    public class TreeNode
    {
        public TreeNode Parent { get; set; }
        public FileType Type { get; set; }
        public List<TreeNode> Children { get; set; }
        public string Name { get; set; }
        public int FileSize { get; set; } = 0;

        public TreeNode(string name, FileType type, TreeNode? parent = null, int size = 0) 
        {
            Parent = parent;
            Name = name;
            Type = type;
            FileSize += size;
            Children = new List<TreeNode>();
        }

        public TreeNode GetChildNode(string dirName)
        {
            foreach (TreeNode child in Children)
            {
                if (child.Name == dirName)
                    return child;
            }

            return null;
        }
    }
    public static int UpdateFileSizes(TreeNode node)
    {
        int TotalDirSize = 0;
        foreach (TreeNode child in node.Children)
        {
            switch (child.Type)
            {
                case FileType.File:
                    TotalDirSize += child.FileSize;
                    break;
                case FileType.Directory:
                    TotalDirSize += UpdateFileSizes(child);
                    break;
            }
        }

        if (node.Type == FileType.Directory)
        {
            node.FileSize = TotalDirSize;

            if (TotalDirSize < 100001)
            {
                answer += node.FileSize;
                Console.WriteLine("name: {0} size: {1}", node.Name, node.FileSize);
            }
            else if( TotalDirSize > 1412830)
            {
                highestDirs.Add(node);
            }
        }

        return TotalDirSize;
    }

    public static void FindLowestFileSize()
    {
        TreeNode lowest = null;
        foreach (TreeNode node in highestDirs)
        {
            if( lowest == null)
                lowest = node;
            else if( lowest.FileSize > node.FileSize ) 
            {
                lowest = node;
            }
        }

        Console.WriteLine(lowest.FileSize);
    }

    public enum FileType
    {
        Directory,
        File
    }
}