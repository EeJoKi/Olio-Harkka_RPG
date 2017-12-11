using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Tools
    {
        int screenWidth = 20;
        int screenHeight = 10;
        int enemySpriteY = 1;
        int screenUpdateSpeed = 200;
        bool jumping = false;

        List<string> enemySprite = new List<string>()
        {"  \\/  ",
         "  OO ",
         "//()\\\\",
         "¤ () ¤"};

        List<string> enemySpriteJump = new List<string>()
        {"  \\/  ",
         "¤ OO ¤",
         "\\\\()//",
         "  ()  "};

        List<string> enemySpriteDamage = new List<string>()
        {"  \\/  ",
         "  --  ",
         "//()\\\\",
         "¤ () ¤"};

        int enemySpriteWidth = 6;

        string enemyBase = "(////)";

        public void UpdateScreen()
        {
            //WriteFrames
            Console.WriteLine(String.Concat(Enumerable.Repeat("/", screenWidth)));

            for (int i = 0; i < screenHeight; i++)
            {
                Console.WriteLine("/" + String.Concat(Enumerable.Repeat(" ", screenWidth-2)) + "/");
            }
            Console.WriteLine(String.Concat(Enumerable.Repeat("/", screenWidth)));
            Console.SetCursorPosition(Console.CursorLeft + screenWidth / 2 - enemyBase.Length/2, Console.CursorTop - 3);

            //DrawBase
            Console.WriteLine(enemyBase);

            //WriteEnemy
            Console.SetCursorPosition(Console.CursorLeft + screenWidth / 2 - enemySpriteWidth/2, Console.CursorTop - enemySpriteY - enemySprite.Count);
            for (int i = 0; i < enemySprite.Count; i++)
            {
                if (jumping == false)
                {
                    Console.WriteLine(enemySprite[i]);
                }
                else if (jumping == true)
                {
                    Console.WriteLine(enemySpriteJump[i]);
                }
                Console.SetCursorPosition(Console.CursorLeft + screenWidth/2 - enemySpriteWidth/2, Console.CursorTop);
            }
           

            //EnemyJumps
            Console.SetCursorPosition(Console.CursorLeft + screenWidth / 2, Console.CursorTop + enemySpriteY + enemySprite.Count);
            if (jumping == true)
            {
                enemySpriteY -= 1;
                jumping = false;
            }
            else
            {
                enemySpriteY += 1;
                jumping = true;
            }
            System.Threading.Thread.Sleep(screenUpdateSpeed);
            Console.Clear();
            UpdateScreen();
        }
    }
}
