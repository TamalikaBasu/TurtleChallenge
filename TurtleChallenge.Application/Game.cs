using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TurtleChallenge.GameObjects;
using Newtonsoft.Json;

namespace TurtleChallenge.Application
{
    public class Game
    {
        private static Configuration GetConfiguration(string configFile)
        {
            try
            {
                string file = File.ReadAllText(configFile + ".json");
                var configuration = JsonConvert.DeserializeObject<Configuration>(file);
                return configuration;
            }
            catch (Exception)
            {
                return null;
                throw;
            }
        }

        public static Sequence GetSequence(string actionsFile)
        {
            try
            {
                string file = File.ReadAllText(actionsFile + ".json");
                var sequence = JsonConvert.DeserializeObject<Sequence>(file);
                return sequence;
            }
            catch (Exception)
            {
                return null;
                throw;
            }
        }

        public static Stage Configure(string configFile)
        {
            var configuration = GetConfiguration(configFile);

            if (configuration != null)
            {
                if (configuration.Validate(configuration.Board,
                                            configuration.Turtle,
                                            configuration.Mines,
                                            configuration.Exit)
                )
                {
                    var board = configuration.Board;
                    board.Populate(configuration.Mines, configuration.Exit);

                    var turtle = configuration.Turtle;

                    return new Stage()
                    {
                        Board = board,
                        Turtle = turtle
                    };
                }
                else
                {
                    Console.WriteLine("Configuration is invalid.");
                }
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Configuration file do not exist or it is invalid.");
                Console.ResetColor();
            }

            return null;
        }
    }
}
