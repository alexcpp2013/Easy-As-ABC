using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace kiselev1
{
    public abstract class IGame
    {
        public abstract void initArrays();
        public abstract Tuple<byte, string> doneAlgorithmTask();
        public abstract void clearArrays();
    }
}
