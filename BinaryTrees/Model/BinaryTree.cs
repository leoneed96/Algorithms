using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.BinaryTrees.Model
{
    public class BinaryTree<T> where T: IComparable
    {
        public TreeNode<T> Head { get; private set; }
        public int Count { get; private set; }

        public void Add(T value)
        {
            Count++;
            if (Head == null)
            {
                Head = new TreeNode<T>(value);
                return;
            }
            var newValueSmallerThanCurrent = Head.Value.CompareTo(value) > 0;
            var direction = newValueSmallerThanCurrent ? TreeDirection.Left : TreeDirection.Right;
            HelpAddNode(Head, direction, value);
        }

        public TreeNode<T> GetFirstNodeByValue(T value, out TreeNode<T> parent)
        {
            if(Head == null)
            {
                parent = null;
                return null;
            }
            return HelpGetFirstNodeByValue(value, out parent, Head);
        }

        private TreeNode<T> HelpGetFirstNodeByValue(T value, out TreeNode<T> parent, TreeNode<T> searchFrom, TreeNode<T> previous = null)
        {
            parent = previous;
            if (searchFrom.Value.CompareTo(value) == 0)
            {
                return searchFrom;
            }
            var currentValueGreater = searchFrom.Value.CompareTo(value) > 0;
            // current.val > searchVal - search left, else right
            if (currentValueGreater)
                return searchFrom.Left == null ? null : HelpGetFirstNodeByValue(value, out parent, searchFrom.Left, searchFrom);
            return searchFrom.Right == null ? null : HelpGetFirstNodeByValue(value, out parent, searchFrom.Right, searchFrom);
        }

        public bool Remove(T value)
        {
            var nodeToRemove = GetFirstNodeByValue(value, out TreeNode<T> parent);
            if (nodeToRemove == null)
                return false;

            Count--;
            // left child of removing node becomes current(removing) node
            if (nodeToRemove.Right == null)
            {
                if (parent != null)
                {
                    // removing left child of parent
                    if (nodeToRemove.Value.CompareTo(parent.Value) < 0)
                        parent.Left = nodeToRemove.Left;
                    else
                        parent.Right = nodeToRemove.Left;
                }
                else Head = nodeToRemove.Left;
                return true;
            }
            // right child of removing node becomes current node
            else if(nodeToRemove.Right.Left == null)
            {
                if(parent != null)
                {
                    if (nodeToRemove.Value.CompareTo(parent.Value) < 0)
                        parent.Left = nodeToRemove.Right;
                    else
                        parent.Right = nodeToRemove.Right;
                }
                nodeToRemove = nodeToRemove.Right;
                return true;
            }
            // right child has left child -> last left child of right subtree becomes current node
            // 
            else
            {
                var lastLeftChild = nodeToRemove.Right.Left;
                var lastLeftChildParent = nodeToRemove.Right;
                while (lastLeftChild.Left != null)
                {
                    lastLeftChildParent = lastLeftChild;
                    lastLeftChild = lastLeftChild.Left;
                }
                // transfering removing node's children to last left child
                lastLeftChild.Left = nodeToRemove.Left;
                lastLeftChild.Right = nodeToRemove.Right;
                // transfering right child of last left child to last left child's place
                lastLeftChildParent.Left = lastLeftChild.Right;
                // setting last left child instead of removing node
                if (parent != null)
                {
                    if (nodeToRemove.Value.CompareTo(parent.Value) < 0)
                        parent.Left = lastLeftChild;
                    else
                        parent.Right = lastLeftChild;
                }
                lastLeftChildParent.Left = null;
                return true;
            }
        }

        public void Clear()
        {
            Count = 0;
            Head = null;
        }

        private TreeNode<T> GetExtremeLastNode(TreeNode<T> source, TreeDirection direction)
        {
            var last = direction == TreeDirection.Left ? source.Left : source.Right;
            if (last == null)
                return source;
            return GetExtremeLastNode(last, direction);
        }


        private void HelpAddNode(TreeNode<T> tree, TreeDirection direction, T newValue)
        {
            if (direction == TreeDirection.Left)
            {
                if (tree.Left == null)
                {
                    tree.Left = new TreeNode<T>(newValue);
                    return;
                }
                else if (tree.Left.Value.CompareTo(newValue) > 0)
                {
                    HelpAddNode(tree.Left, TreeDirection.Left, newValue);
                }
                else
                    HelpAddNode(tree.Left, TreeDirection.Right, newValue);
            }
            else
            {
                if (tree.Right == null)
                {
                    tree.Right = new TreeNode<T>(newValue);
                    return;
                }
                else if (tree.Right.Value.CompareTo(newValue) > 0)
                {
                    HelpAddNode(tree.Right, TreeDirection.Left, newValue);
                }
                else
                    HelpAddNode(tree.Right, TreeDirection.Right, newValue);
            }
        }
    }

    enum TreeDirection
    {
        Left, Right
    }
}
