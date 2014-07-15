using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatchSummary.Model
{
    /// <summary>
    /// Match teams
    /// </summary>
    public class MatchInformation
    {
        public string homeTeam { get; set; }
        public string awayTeam { get; set; }
        public int scoreHome { get; set; }
        public int scoreAway { get; set; }
    }

    /// <summary>
    /// Match events
    /// </summary>
    public class MatchEvents
    {
        public string type { get; set; }
        public string team { get; set; }
        public int minute { get; set; }
        public string player { get; set; }
    }
}
