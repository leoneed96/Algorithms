using Algorithms.BinaryTrees.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.BinaryTrees.Traversing
{
    public interface IBinaryTreeTraversal
    {
        void PerformTraversal<T>(Action<T> action, BinaryTree<T> tree) where T: IComparable;
    }
}
