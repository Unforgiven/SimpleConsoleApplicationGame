using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnilAdvance
{
    class Game
    {
        public static bool gameStatus = true;
        public static int activeBoth = 0;

        public static Ground[,,] map = new Ground[View.frameLength, View.frameWidth, View.frameHeigth];
        public static Both[] player = new Both[3];

        public static void start()
        {
            objectsInitialize();
            buildMap();
            Parasit.parasitCount();

            while (gameStatus)
            {
                //View.fillingMap();
                View.setHeightLevel();
                View.renderMap();

                string readKey = Console.ReadLine();
                moveHero(readKey);

                if (Parasit.count == 0)
                    finish();
            }   
        }

        public static void moveHero(string key)
        {
            switch (key)
            {
                case "1": { player[activeBoth%player.Length].moveForvard();  } return; //Шаг вперёд
                case "2": { player[activeBoth%player.Length].rotate(false); } return; //Поворот против часовой стрелки
                case "3": { player[activeBoth%player.Length].rotate(true); } return; //Поворот по часовой стрелке
                case "4": { player[activeBoth%player.Length].jump(player[activeBoth % player.Length].checkLevel()); } return; //Прыжок
                case "5": { player[activeBoth%player.Length].activate(); } return; //Активация предмета
                case "6": { activeBoth++; } return; //Смена игрока

                case "finish": { finish(); } return; //завершить игру
                case "debug": { debug(); } return; //проверка уровеней высоты
            }
        }

        public static void objectsInitialize()
        {
            for (int x = 0; x < View.frameLength; x++)
                for (int y = 0; y < View.frameWidth; y++)
                    for (int z = 0; z < View.frameHeigth; z++)
                        map[x, y, z] = new Ground();

            map[2, 2, 1] = new Parasit();
            map[6, 7, 2] = new Parasit();
            map[13, 8, 3] = new Parasit();
            map[6, 0, 4] = new Parasit();
            map[1, 12, 5] = new Parasit();

            player[0] = new Both(0, 0, 1);
            player[1] = new Both(7, 1, 4);
            player[2] = new Both(1, 7, 5);

            map[5, 7, 2] = new Teleport(1, 11, 5);
            map[1, 11, 5] = new Teleport(5, 7, 2);            
        }

        public static void buildMap()
        {
            //временная функция для демонстрации возможностей новой версии
            for (int x = 0; x < View.frameLength; x++)
                for (int y = 0; y < View.frameWidth; y++)
                {
                    map[x, y, 0].isVoid = false;
                    map[x, y, 1].isVoid = false;
                }

            for (int x = 0; x < 5; x++)
                for (int y = 0; y < 5; y++)
                    map[x, y, 1].isVoid = true;

            for (int z = 0; z < View.frameWidth; z++)
            {
                map[z, View.frameWidth - 1, 1].isVoid = false;
                map[z, View.frameWidth - 2, 1].isVoid = false;
            }

            for (int z = 0; z < View.frameLength; z++)
            {
                map[View.frameLength - 1, z, 2].isVoid = false;
                map[View.frameLength - 2, z, 2].isVoid = false;
            }

            for (int z = 0; z < View.frameWidth; z++)
            {
                map[z, 0, 3].isVoid = false;
                map[z, 1, 3].isVoid = false;
            }

            for (int z = 0; z < View.frameLength; z++)
            {
                map[0, z, 4].isVoid = false;
                map[1, z, 4].isVoid = false;
            }

            for (int z = 0; z < View.frameWidth; z++)
            {
                map[z, View.frameWidth - 1, 5].isVoid = false;
                map[z, View.frameWidth - 2, 5].isVoid = false;
            }

            for (int z = 0; z < View.frameLength; z++)
            {
                map[View.frameLength - 1, z, 6].isVoid = false;
                map[View.frameLength - 2, z, 6].isVoid = false;
            }

            for (int z = 0; z < View.frameWidth; z++)
            {
                map[z, 0, 7].isVoid = false;
                map[z, 1, 7].isVoid = false;
            }

            for (int z = 0; z < View.frameLength; z++)
            {
                map[0, z, 8].isVoid = false;
                map[1, z, 8].isVoid = false;
            }
        }

        public static void finish()
        {
            Game.gameStatus = false;
            Console.Clear();
            Console.WriteLine("YOU WIN!");
            Console.ReadLine();
        }

        public static void debug()
        {
            Game.gameStatus = false;
            Console.Clear();

            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine();
            }

            Console.ReadLine();
        }
    }
}
