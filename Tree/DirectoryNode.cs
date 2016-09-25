using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Tree
{
    class DirectoryNode
    {
        public DirectoryNode(DirectoryInfo dir, DirectoryNode parent)
        {
            Directory = dir;

            if (parent != null)
            {
                IsLast = parent.Directory.GetDirectories().Last().FullName == dir.FullName;
                Parents = new List<DirectoryNode>(parent.Parents) { parent };
            }
        }

        public bool IsLast { get; } = true;
        public IEnumerable<DirectoryNode> Parents { get; } = Enumerable.Empty<DirectoryNode>();
        public DirectoryInfo Directory { get; }
    }
}
