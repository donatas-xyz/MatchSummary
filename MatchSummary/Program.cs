using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MatchSummary.Controller;

namespace MatchSummary
{
    class Program
    {
        static void Main(string[] args)
        {
            JSONProcess startJSON = new JSONProcess();

            /// Path defined by external entity. 
            string path = @"../../../MatchSummary/Data/resultsLoaded.json";
            startJSON.SetFile(path);

            startJSON.ShowInformation();

            /// Prevents console window from closing.
            Console.ReadLine();
        }
    }
}
