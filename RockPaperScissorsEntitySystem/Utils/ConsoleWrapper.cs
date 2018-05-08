using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RockPaperScissorsEntitySystem.Utils
{
    public class ConsoleWrapper : IConsole
    {
        object syncRoot = new object();

        public ConsoleWrapper()
        {
            Console.CursorVisible = false;
        }
        public void WriteAt(int left, int top, string text)
        {
            lock (syncRoot)
            {
                var orgLeft = Console.CursorLeft;
                var orgTop = Console.CursorTop;
                Console.SetCursorPosition(left, top);
                Console.Write(text);
                Console.SetCursorPosition(orgLeft, orgTop);
            }
        }
        public char ReadChar()
        {

            return Console.ReadKey(true).KeyChar;

        }
        public int WindowHeight
        {
            get
            {

                return Console.WindowHeight;

            }
        }
        public int WindowWidth
        {
            get
            {

                return Console.WindowWidth;

            }
        }
        public void ReadLine()
        {
            Console.ReadLine();
        }
    }
}
