using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace TurtleChallenge.GameObjects
{
    public class Configuration
    {
        [JsonProperty("board")]
        public Board Board { get; set; }

        [JsonProperty("turtle")]
        public Turtle Turtle { get; set; }

        [JsonProperty("exit")]
        public Position Exit { get; set; }

        [JsonProperty("mines")]
        public List<Position> Mines { get; set; }

        public bool Validate(Board board)
        {
            if (board.SizeX <= 0 || board.SizeY <= 0)
            {
                throw new Exception("Unable to load board size or it is invalid.");
            }

            return true;
        }

        public bool Validate(Turtle turtle)
        {
            if (turtle.PosX < 0 || turtle.PosY < 0)
            {
                throw new Exception("Unable to load Turle start position or it is invalid.");
            }

            return true;
        }

        public bool Validate(List<Position> mines)
        {
            foreach (var mine in mines.Select((value, i) => new { i, value }))
            {
                if (mine.value.PosX < 0 || mine.value.PosY < 0)
                {
                    throw new Exception($"Unable to load Mine { mine.i } or it is invalid.");
                }
            }

            return true;
        }

        public bool Validate(Position exit)
        {
            if (exit.PosX < 0 || exit.PosY < 0)
            {
                throw new Exception("Unable to load Exit position or it is invalid.");
            }

            return true;
        }

        public bool Validate(Board board, Turtle turtle, List<Position> mines, Position exit)
        {
            if (Validate(board) && Validate(turtle) && Validate(mines) && Validate(exit)) {
                return true;
            }

            return false;
        }
    }
}
