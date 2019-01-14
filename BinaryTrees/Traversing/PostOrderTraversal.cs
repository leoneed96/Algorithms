using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Algorithms.BinaryTrees.Model;

namespace Algorithms.BinaryTrees.Traversing
{
    public class PostOrderTraversal : IBinaryTreeTraversal
    {
        public void PerformTraversal<T>(Action<T> action, BinaryTree<T> tree) where T : IComparable
        {
            if (tree == null)
                throw new ArgumentException("tree");
            HelpPerformTraversal(action, tree.Head);
        }
        private void HelpPerformTraversal<T>(Action<T> action, TreeNode<T> node) where T : IComparable
        {
            if (node == null)
                return;
            HelpPerformTraversal(action, node.Left);
            HelpPerformTraversal(action, node.Right);
            action(node.Value);
        }
    }
}
