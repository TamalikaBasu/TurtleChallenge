using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace TurtleChallenge.GameObjects
{
    public class Position
    {
        [JsonProperty("pos_x")]
        public int PosX { get; set; }
        [JsonProperty("pos_y")]
        public int PosY { get; set; }
    }
}
