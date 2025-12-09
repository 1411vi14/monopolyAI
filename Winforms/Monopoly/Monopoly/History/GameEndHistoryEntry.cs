namespace Monopoly.History
{
    internal class GameEndHistoryEntry : IHistoryEntry
    {
        public string WinnerName { get; }
        public GameEndHistoryEntry(string winnerName)
        {
            WinnerName = winnerName;
        }
        public override string ToString()
        {
            return $"Game ended. Winner: {WinnerName}";
        }
	}
}
