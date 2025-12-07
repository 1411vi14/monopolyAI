namespace Monopoly
{
    public class Setting
    {
        public int NumberPlayers { get; private set; } = 2;

        public Setting(int numberPlayers = 2) 
        {

        NumberPlayers = numberPlayers;

        }
    }
}
