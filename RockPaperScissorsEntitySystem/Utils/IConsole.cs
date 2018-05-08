namespace RockPaperScissorsEntitySystem.Utils
{
    public interface IConsole
    {
        int WindowHeight { get; }
        int WindowWidth { get; }

        void WriteAt(int left, int top, string text);
        char ReadChar();
        void ReadLine();
    }
}