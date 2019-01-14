using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.BinaryTrees.Model
{
    public class TreeNode<T> where T: IComparable
    {
        public TreeNode<T> Left { get; set; }
        public string LeftVal { get => Left != null ? Left.Value.ToString() : null; } 
        public string RightVal { get => Right != null ? Right.Value.ToString() : null; } 
        public TreeNode<T> Right { get; set; }
        public T Value { get; private set; }

        public TreeNode(T value)
        {
            Value = value;
        }
    }
}
