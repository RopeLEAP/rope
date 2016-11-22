using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rope
{
    class RopeNode<T>
    {
        internal const int NodeSize = 2;
        internal RopeNode<T> left, right;
        internal T[] contents;
        internal byte height;
        internal int length;

        

        //internal static readonly RopeNode<T> emptyRopeNode = new RopeNode<T> { isShared = true, contents = new T[RopeNode<T>.NodeSize] };
        //public RopeNode right;
        //public RopeNode left;
        //public int weight;
        //public string subString;

        //public int getCharacterAtIndex(RopeNode node, int i)
        //{
        //    if (node.weight < i)
        //    {
        //        return getCharacterAtIndex(node.right, i - node.weight);
        //    }
        //    else
        //    {
        //        if(node.left != null)
        //        {
        //            return getCharacterAtIndex(node.left, i);
        //        }
        //        else
        //        {
        //            return node.left.subString[i];
        //        }
        //    }
        //}

        internal static RopeNode<T> CreateFromArray(T[] arr, int index, int length)
        {
            //if (length == 0)
            //{
            //    return emptyRopeNode;
            //}
            RopeNode<T> node = CreateNodes(length);
            return node.StoreElements(0, arr, index, length);
        }

        private RopeNode<T> StoreElements(int index, T[] array, int arrayIndex, int count)
        {
            RopeNode<T> result = this.CloneIfShared();
            // result cannot be function node after a call to Clone()
            if (result.height == 0)
            {
                // leaf node:
                Array.Copy(array, arrayIndex, result.contents, index, count);
            }
            else
            {
                // concat node:
                if (index + count <= result.left.length)
                {
                    result.left = result.left.StoreElements(index, array, arrayIndex, count);
                }
                else if (index >= this.left.length)
                {
                    result.right = result.right.StoreElements(index - result.left.length, array, arrayIndex, count);
                }
                else
                {
                    int amountInLeft = result.left.length - index;
                    result.left = result.left.StoreElements(index, array, arrayIndex, amountInLeft);
                    result.right = result.right.StoreElements(0, array, arrayIndex + amountInLeft, count - amountInLeft);
                }
                result.Rebalance(); // tree layout might have changed if function nodes were replaced with their content
            }
            return result;
        }

        //TODO: Implement
        private void Rebalance()
        {
            return;
        }

        private RopeNode<T> CloneIfShared()
        {
            return this;
        }

        private static RopeNode<T> CreateNodes(int totalLength)
        {
            int leafCount = (totalLength + NodeSize - 1) / NodeSize;
            return CreateNodes(leafCount, totalLength);
        }

        private static RopeNode<T> CreateNodes(int leafCount, int totalLength)
        {
            RopeNode<T> result = new RopeNode<T>();
            result.length = totalLength;
            if(leafCount == 1)
            {
                result.contents = new T[NodeSize];
            }
            else
            {
                int rightSide = leafCount / 2;
                int leftSide = leafCount - rightSide;
                int leftLength = leftSide * NodeSize;
                result.left = CreateNodes(leftSide, leftLength);
                result.right = CreateNodes(rightSide, totalLength - leftLength);
                result.height = (byte)(1 + Math.Max(result.left.height, result.right.height));
            }
            return result;
        }
    }
}
