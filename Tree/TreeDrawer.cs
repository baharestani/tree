using System;
using System.IO;
using System.Linq;

namespace Tree
{
    class TreeDrawer
    {
        private Action<string> write;


        public void Draw(string directory, Action<string> write)
        {
            this.write = write;
            Traverse(new DirectoryNode(new DirectoryInfo(directory), null));
        }

        private void Traverse(DirectoryNode currentNode)
        {
            foreach (var parent in currentNode.Parents)
            {
                write((parent.IsLast ? " " : "│") + new string(' ', 3));
            }

            if (currentNode.Parents.Any())
                write((currentNode.IsLast ? "└" : "├") + "───");

            write(currentNode.Directory.Name + Environment.NewLine);

            var children = currentNode.Directory.GetDirectories();
            foreach (var item in children)
            {
                var node = new DirectoryNode(item, currentNode);
                Traverse(node);
            }

        }
    }
}
