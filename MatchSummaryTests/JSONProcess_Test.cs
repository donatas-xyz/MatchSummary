using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MatchSummary.Controller;
using System.IO;

namespace MatchSummaryTests
{
    /// <summary>
    /// Just to demonstrate my awareness of TDD
    /// </summary>
    [TestClass]
    public class JSONProcess_Test
    {
        JSONProcess data = new JSONProcess();

        [TestMethod]
        public void SetFileTest_FileExists()
        {
            string pathSet = @"../../../MatchSummary/Data/testFile.json";
            data.SetFile(pathSet);

            StreamReader reader = new StreamReader(data.path);
            string pathRetrieved = data.path;

            Assert.AreEqual(pathSet, pathRetrieved);
        }

        [TestMethod]
        [ExpectedException(typeof(FileNotFoundException))]
        public void SetFileTest_FileDoesNOTExist()
        {
            string pathSet = @"../../../MatchSummary/Data/FakeFile.txt";
            data.SetFile(pathSet);
        }
    }
}
