using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AnySportScoresFilesProcessor.BusinessLogic;
using AnySportScoresFilesProcessor.Models;
using System.IO;
using System.Linq;

namespace FootballScoresProcessorUnitTests
{
    [TestClass]
    public class UnitTest1
    {
        string sampleFilePath = Path.Combine(Path.GetFullPath(@"..\..\"), "SampleSportScoreFiles");

        [TestMethod]
        public void TestStreamReaderForInvalidPath()
        {
            AnySportScoresFileProcessor processor = new AnySportScoresFileProcessor("XYZ");
            processor.ProcessFile();

            Assert.IsNull(processor.CorrespondingSportScoreFile);
        }

        [TestMethod]
        public void TestBlankFile()
        {
            AnySportScoresFileProcessor processor = new AnySportScoresFileProcessor(Path.Combine(sampleFilePath, "football_blank_file.csv"));
            processor.ProcessFile();

            Assert.AreEqual(0, processor.CorrespondingSportScoreFile.AllRecords.Count);
        }

        [TestMethod]
        public void TestFileWithImproperName()
        {
            AnySportScoresFileProcessor processor = new AnySportScoresFileProcessor(Path.Combine(sampleFilePath, "InvalidName.csv"));
            processor.ProcessFile();

            Assert.AreEqual(0, processor.CorrespondingSportScoreFile.AllRecords.Count);
        }

        [TestMethod]
        public void TestFootballFileWithOneRowOfCorruptData()
        {
            AnySportScoresFileProcessor processor = new AnySportScoresFileProcessor(Path.Combine(sampleFilePath, "football_CorruptData.csv"));
            processor.ProcessFile();
            processor.ExecuteAllRules();

            Assert.AreEqual(2, processor.CorrespondingSportScoreFile.AllRecords.Count);
            Assert.AreEqual(37, processor.CorrespondingSportScoreFile.AllRulesResults.Min(rr => rr.result));
         }

        [TestMethod]
        public void TestFootballFileWithProperData()
        {
            AnySportScoresFileProcessor processor = new AnySportScoresFileProcessor(Path.Combine(sampleFilePath, "football_ProperData.csv"));
            processor.ProcessFile();
            processor.ExecuteAllRules();

            Assert.AreEqual(4, processor.CorrespondingSportScoreFile.AllRecords.Count);
            Assert.AreEqual(22, processor.CorrespondingSportScoreFile.AllRulesResults.Min(rr => rr.result));
        }
    }
}