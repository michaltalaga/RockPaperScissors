using System;
using System.Linq;

namespace RockPaperScissors
{
    public class ConsoleWrapper : IUserInput
    {
        public char GetUserInput()
        {
            ShowPrompt();
            var c = Console.ReadKey(true).KeyChar;
            HidePrompt();
            return c;
        }

        static void HidePrompt()
        {
            int origRow = Console.CursorTop;
            int origCol = Console.CursorLeft;


            try
            {
                Console.SetCursorPosition(0, Console.WindowHeight - 1);
                Console.Write("".PadRight(Console.WindowWidth-1, ' '));
            }
            catch (ArgumentOutOfRangeException e)
            {

            }
            finally
            {
                try
                {
                    Console.SetCursorPosition(origCol, origRow);
                }
                catch (ArgumentOutOfRangeException e)
                {
                }
            }
        }

        static string helpString;
        static void ShowPrompt()
        {
            if (helpString == null)
            {
                helpString = "Choose: " + string.Join(", ", ((int[])Enum.GetValues(typeof(Move))).Select(v => v + " - " + Enum.GetName(typeof(Move), v)));
            }

            int origRow = Console.CursorTop;
            int origCol = Console.CursorLeft;
            

            try
            {
                Console.SetCursorPosition(0, Console.WindowHeight - 1);
                Console.Write(helpString);
            }
            catch (ArgumentOutOfRangeException e)
            {

            }
            finally
            {
                try
                {
                    Console.SetCursorPosition(origCol, origRow);
                }
                catch (ArgumentOutOfRangeException e)
                {
                }
            }

        }
    }


}
