namespace RockPaperScissorsEntitySystem.Utils
{
    public class Random : IRandom
    {
        System.Random random = new System.Random();


        /// <summary>
        /// 
        /// </summary>
        /// <param name="min">inclusive</param>
        /// <param name="max">inclusive</param>
        /// <returns></returns>
        public int Next(int min, int max)
        {
            return random.Next(min, max + 1);
        }
    }


}
