namespace HLGame.Interface
{
    public interface IDBContext : IDBGame, IDBHighScore
    {
    }

    public interface IDBGame
    {
        public IGame GetGame(int ID);
        public bool SaveGame();
    }

    public interface IDBHighScore
    {
        public IHighScore[] GetHighScores();
        public bool SaveHighScore(IHighScore Score);
    }
}