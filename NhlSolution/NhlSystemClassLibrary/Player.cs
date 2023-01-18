using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhlSystemClassLibrary
{
    public class Player
    {
        const int MinPlayerNo = 1;
        const int MaxPlayerNo = 98;

        private int _playerNo;
        private string _playerName;
        private int _gamesPlayed;
        private int _goals;
        private int _assists;
        // TODO: Define properties for:
        // 1) PlayerNo: int {PlayerNo >= 1 and PlayerNo <= 98}
        public int PlayerNo
        {
            get => _playerNo;
            private set
            {
                if (value < MinPlayerNo || value > MaxPlayerNo)
                {
                    throw new ArgumentException($"PlayerNo must be between {MinPlayerNo} and {MaxPlayerNo}");
                }
                _playerNo = value;
            }
        }
        // 2) Name: string {cannot be blank}
        public string Name
        {
            get => _playerName;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Name cannot be blank.");
                }
                _playerName = value.Trim();
            }
        }
        // 3) Position: Position
        public Position Position { get; private set; }
        // 4) GamesPlayed: int {GamesPlayed >= 0}
        public int GamesPlayed
        {
            get => _gamesPlayed;
            protected set
            {
                if (!Utilities.IsPositiveOrZero(value))
                {
                    throw new ArgumentException("GamesPlayed must be a positive or zero number.");
                }
            }
        }
        // 5) Goals: int {Goals >= 0}
        public int Goals
        {
            get => _goals;
            private set
            {
                if (!Utilities.IsPositiveOrZero(value))
                {
                    throw new ArgumentException("Goals must be a positive or zero number.");
                }
            }
        }
        // 6) Assists: int {Assists >= 0}
        public int Assists
        {
            get => _assists;
            private set
            {
                if (!Utilities.IsPositiveOrZero(value))
                {
                    throw new ArgumentException("Assists must be a positive or zero number.");
                }
            }
        }
        // 7) Points : int { Goals + Assists}
        //public int Points => Goals + Assists;
        public int Points
        {
            get
            {
                return Goals + Assists;
            }
        }

        // TODO: Define constructor with parameters for:
        // PlayerNo, Name, Positiion
        // PlayerNo, Name, Positiion, GamesPlayed, Goals, Assists
        public Player(int playerNo, string name, Position position)
        {
            PlayerNo = playerNo;
            Name = name;
            Position = position;
        }
        public Player(int playerNo, string name, Position position, int gamesPlayed, int goals, int assists)
        {
            PlayerNo = playerNo;
            Name = name;
            Position = position;
            GamesPlayed = gamesPlayed;
            Goals = goals;
            Assists = assists;
        }

        // TODO: Define methods to
        // 1) add 1 to GamesPlayed
        // 2) add 1 to Goals
        // 3) add 1 to Assists
        public void AddGamesPlayed()
        {
            GamesPlayed += 1;
        }
        public void AddGoals()
        {
            Goals += 1;
        }
        public void AddAssist()
        {
            Assists++;
        }

        
    }
}
