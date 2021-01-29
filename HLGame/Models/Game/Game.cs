using HLGame.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static HLGame.Interface.IGameState;

namespace HLGame.Models.Game
{

    public abstract class GuessGame<AnswerType> : IGame,IGuess<AnswerType>, ICRUD
    {
        private const int NumberOfRounds = 10;
        private const int PointsAwarded = 1;

        IDBContext _db;

        public eState State = eState.Active;
        public string Name { get; set; }
        public int ID { get; set; }

        public int[] Numbers { get; set; }
        public int Score { get; set; }

        private INumbersBoard _numbersBoard;

        public INumbersBoard NumbersBoard
        {
            get { return _numbersBoard; }
            set { _numbersBoard = value; }
        }

        public DateTime StartDate { get; set ; }

        public GuessGame() { }

        public GuessGame(IDBContext db, INumbersBoard board)
        {
            _db = db;
            _numbersBoard = board;
        }

        public GuessGame(IDBContext db, INumbersBoard board, int id) : this(db, board)
        {
            ID = id;
            Get();
        }

        public bool End(eState state)
        {
            this.State = state;
            switch (State)
            {
                case eState.Active:
                case eState.Success:
                    return true;
            }

            return false;
        }

        public void Get()
        {
            var dbGame = _db.GetGame(ID);

            if (dbGame == null || dbGame.ID != ID)
                throw new Exception("cannot find game");

            Map(dbGame);
        }

        private void Map(IGame dbGame)
        {
            this.ID = dbGame.ID;
            this.Numbers = dbGame.Numbers;
            this.Score = dbGame.Score;
        }

        private void AddToScore()
        {
            Score += PointsAwarded;
        }

        protected void ValidateAnswer(bool Correct)
        {
            if (State != eState.Active)
            {
                return;
            }

            if (Correct)
                AddToScore();
            else
            {
                State = eState.GameOver;
            }


            if (!NumbersBoard.MoveToNextNumber())
            {
                State = eState.Success;
                var HighScore = new HighScore()
                {
                    Name = Name,
                    Score = Score,
                    Time = DateTime.Now.Subtract(StartDate),
                    GameID = 0
                };

                _db.SaveHighScore(HighScore);
            }

            
        }

        public abstract bool Guess(AnswerType Answer);

        public bool Update()
        {
            return _db.SaveGame();
        }

        public bool Insert()
        {
            return _db.SaveGame();
        }

        public bool Delete()
        {
            throw new NotImplementedException();
        }
    }


}
