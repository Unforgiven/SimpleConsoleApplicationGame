using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnilAdvance
{
    class Ground
    {
        public char sym = 'o';
        public bool isVoid;
        public ConsoleColor color;

        public Ground()
        {
            isVoid = true;
            color = ConsoleColor.White;
        }

        virtual public void activate()
        {
            
        }
    }
}
