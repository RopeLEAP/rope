﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rope
{
    /// <summary>
    /// Provides immutable empty list instances.
    /// </summary>
    static class Empty<T>
    {
        public static readonly T[] Array = new T[0];
        //public static readonly ReadOnlyCollection<T> ReadOnlyCollection = new ReadOnlyCollection<T>(Array);
    }
}
