using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MatchSummary.Model;

namespace MatchSummary.Controller
{
    public class JSONProcess
    {
        /// Default path
        public string path = @"../../../MatchSummary/Data/resultsLoaded.json";
        /// <summary>
        /// Path defined by user
        /// </summary>
        /// <param name="path">Path to JSON file</param>
        public void SetFile(string path) 
        {      
            if (!File.Exists(path))
            {
                throw new FileNotFoundException();
            }
            else
            {
                this.path = path;
            }
        }

        List<MatchEvents> events = new List<MatchEvents>();
        MatchInformation information = new MatchInformation();

        /// <summary>
        /// Reads JSON file and deserializes it to .NET objects in Model
        /// </summary>
        public void JSONLoad()
        {
            try 
            {
                using (StreamReader reader = File.OpenText(path))
                {
                    JObject o = (JObject)JToken.ReadFrom(new JsonTextReader(reader));

                    JArray a = (JArray)o["matchEvents"];

                    information.homeTeam = (string)o["homeTeam"];
                    information.awayTeam = (string)o["awayTeam"];

                    events = a.Select(p => new MatchEvents
                    {
                        type = (string)p["type"],
                        team = (string)p["team"],
                        minute = (int)p["minute"],
                        player = (string)p["player"]
                    }).ToList();

                    information.scoreHome = (int)events.Where(x => x.type == "goal" && x.team == "home").Count();
                    information.scoreAway = (int)events.Where(x => x.type == "goal" && x.team == "away").Count();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Prints the output to console. Should have been moved to the View... 
        /// </summary>
        public void ShowInformation() 
        {
            JSONLoad();

            Console.WriteLine(information.homeTeam + " " + information.scoreHome + " : " + information.scoreAway + " " + information.awayTeam);

            foreach (var i in events.Select((value, index) => new { value, index }).Where(x => x.value.type == "yellowCard" || x.value.type == "redCard")) // Solution for maintaining index: http://stackoverflow.com/a/4337706
            {
                Console.WriteLine(events[i.index].player + " " + events[i.index].type + " " + events[i.index].minute);
            }
        }
    }
}
