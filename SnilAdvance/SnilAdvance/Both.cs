using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnilAdvance
{
    class Both : Ground
    {
        public static char both = '>';

        public int x, y, z;

        public int rotation = 1000000;

        public Both(int x, int y, int z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
            sym = both;
            isVoid = false;
            color = ConsoleColor.Green;
            Game.map[x, y, z].isVoid = false;
        }

        public void moveForvard()
        {
            switch (rotation % 4)
            {
                case 0:
                    if (y + 1 < View.frameLength && Game.map[x, y + 1, z].isVoid && !Game.map[x, y + 1, z - 1].isVoid)
                        { Game.map[x, y, z].isVoid = true; y++; }
                    break;
                case 1:
                    if (x + 1 < View.frameWidth && Game.map[x + 1, y, z].isVoid && !Game.map[x + 1, y, z - 1].isVoid)
                        { Game.map[x, y, z].isVoid = true; x++;}
                    break;
                case 2:
                    if (y - 1 >= 0 && Game.map[x, y - 1, z].isVoid && !Game.map[x, y - 1, z - 1].isVoid)
                    { Game.map[x, y, z].isVoid = true; y--; }
                    break;
                case 3:
                    if (x - 1 >= 0 && Game.map[x - 1, y, z].isVoid && !Game.map[x - 1, y, z - 1].isVoid)
                    { Game.map[x, y, z].isVoid = true; x--; }
                    break;
            }

            Game.map[x, y, z].isVoid = false;
        }

        public void jump(bool up)
        {
            if(up && z+1 < View.frameHeigth)
                switch (rotation % 4)
                {
                    case 0:
                        if (y + 1 < View.frameLength && Game.map[x, y + 1, z + 1].isVoid)
                        { Game.map[x, y, z].isVoid = true; y++; z++; }
                        break;
                    case 1:
                        if (x + 1 < View.frameWidth && Game.map[x + 1, y, z + 1].isVoid)
                        { Game.map[x, y, z].isVoid = true; x++; z++; }
                        break;
                    case 2:
                        if (y - 1 >= 0 && Game.map[x, y - 1, z + 1].isVoid)
                        { Game.map[x, y, z].isVoid = true; y--; z++; }
                        break;
                    case 3:
                        if (x - 1 >= 0 && Game.map[x - 1, y, z + 1].isVoid)
                        { Game.map[x, y, z].isVoid = true; x--; z++; }
                        break;
                }
            else if(!up && z-1 > 0)
                switch (rotation % 4)
                {
                    case 0:
                        if (y + 1 < View.frameLength && Game.map[x, y + 1, z - 1].isVoid && !Game.map[x, y + 1, z - 2].isVoid)
                        { Game.map[x, y, z].isVoid = true; y++; z--; }
                        break;
                    case 1:
                        if (x + 1 < View.frameWidth && Game.map[x + 1, y, z - 1].isVoid && !Game.map[x + 1, y, z - 2].isVoid)
                        { Game.map[x, y, z].isVoid = true; x++; z--; }
                        break;
                    case 2:
                        if (y - 1 >= 0 && Game.map[x, y - 1, z - 1].isVoid && !Game.map[x, y - 1, z - 2].isVoid)
                        { Game.map[x, y, z].isVoid = true; y--; z--; }
                        break;
                    case 3:
                        if (x - 1 >= 0 && Game.map[x - 1, y, z - 1].isVoid && !Game.map[x - 1, y, z - 2].isVoid)
                        { Game.map[x, y, z].isVoid = true; x--; z--; }
                        break;
                }

            Game.map[x, y, z].isVoid = false;
        }

        public void rotate(bool right)
        {
            if (right)
                rotation++;
            else
                rotation--;

            switch (rotation % 4)
            {
                case 0:
                    both = '>';
                    break;
                case 1:
                    both = 'v';
                    break;
                case 2:
                    both = '<';
                    break;
                case 3:
                    both = 'ʌ';
                    break;
            }

            sym = both;
        }

        public bool checkLevel()
        {
            switch (rotation % 4)
            {
                case 0:
                    if (!Game.map[x, y + 1, z].isVoid)
                        return true;
                    else
                        return false;
                case 1:
                    if (!Game.map[x + 1, y, z].isVoid)
                        return true;
                    else
                        return false;
                case 2:
                    if (!Game.map[x, y - 1, z].isVoid)
                        return true;
                    else
                        return false;
                case 3:
                    if (!Game.map[x - 1, y, z].isVoid)
                        return true;
                    else
                        return false;
            }

            return true;
        }

        override public void activate()
        {
            Game.map[x, y, z].activate();
        }
    }
}
