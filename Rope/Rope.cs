using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rope
{
    public class Rope<T>
    {
        internal RopeNode<T> root;

        internal Rope(RopeNode<T> root)
        {
            this.root = root;
        }

        public Rope()
        {

        }

        public Rope(T[] array, int arrayIndex, int count)
        {
            this.root = RopeNode<T>.CreateFromArray(array, arrayIndex, count);
        }
    }
}
