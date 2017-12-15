using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace TurtleChallenge.GameObjects
{
    public class Sequence
    {
        [JsonProperty("actions")]
        public List<Action> Actions { get;set; }
    }
}
