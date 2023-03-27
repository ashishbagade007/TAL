using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AnySportScoresFilesProcessor.Models;
using System.IO;
using System.Reflection;
using System.Xml;

namespace AnySportScoresFilesProcessor.BusinessLogic
{
    public class AnySportScoresFileProcessor
    {
        #region "private fields"
        IAnySportScoreFile correspondingSportScoreFile;
        string fileName;
        SportType sport;
        XmlNode columnsNode;
        XmlNode rulesNode;
        Logger logger;
        #endregion

        public IAnySportScoreFile CorrespondingSportScoreFile
        {
            get
            {
                if (correspondingSportScoreFile == null)
                    correspondingSportScoreFile = AnySportScoreFileFactory.GetSportFile(sport);

                return correspondingSportScoreFile;
            }
        }

        #region "_ctor"
        public AnySportScoresFileProcessor(string inputFileName)
        {
            fileName = inputFileName;
            sport = GetSportTypeFromFileName(inputFileName);
            logger = Logger.GetLogger();

            string scoreFileIndicesName = System.IO.Path.Combine(System.IO.Path.GetFullPath(@"..\..\"), "AnySportScoreFileStructure", "AnyScoresFileColumns.xml");

            XmlDocument doc = new XmlDocument();
            doc.Load(scoreFileIndicesName);

            columnsNode = doc.SelectSingleNode(@"Sports/Sport[@Type='" + sport + @"']/Columns");
            rulesNode = doc.SelectSingleNode(@"Sports/Sport[@Type='" + sport + @"']/Rules");

            FillAllColumnsData();
            FillAllRulesData();

            if (CorrespondingSportScoreFile != null)
                CorrespondingSportScoreFile.Logger = logger;
        }

        private SportType GetSportTypeFromFileName(string fileName)
        {
            SportType sport = SportType.INVALID;

            if (fileName.Contains(SportType.Football.ToString()))
                sport = SportType.Football;
            if (fileName.Contains(SportType.Cricket.ToString()))
                sport = SportType.Cricket;

            return sport;
        }

        #endregion

        #region Public Methods
        public void ProcessFile()
        {
            bool isFileValid = ValidateFile(fileName);

            if (isFileValid)
                using (StreamReader reader = new StreamReader(fileName))
                {
                    string Linestring = "";// reader.ReadLine();
                    string Delimiter = ",";

                    reader.ReadLine();

                    while ((Linestring = reader.ReadLine()) != null)
                    {
                        string[] fields = Linestring.Split(Delimiter.ToCharArray());
                        FillAllRecordData(fields);
                    }
                }
        }

        private bool ValidateFile(string fileName)
        {
            string fileNameOnlyWithoutExtension = Path.GetFileNameWithoutExtension(fileName);
            return (File.Exists(fileName) &&
                (fileNameOnlyWithoutExtension.ToLower().Contains(SportType.Football.ToString().ToLower()) ||
                fileNameOnlyWithoutExtension.ToLower().Contains(SportType.Cricket.ToString().ToLower())));
        }

        public void ExecuteAllRules()
        {
            foreach (var rule in CorrespondingSportScoreFile.AllRules)
            {
                var actualRule = rule.Value;
                actualRule.ExecuteRule();
            }
        }
        #endregion

        #region Private Methods

        private void FillAllRecordData(string[] fields)
        {
            try
            {
                var nameIndex = CorrespondingSportScoreFile.AllColumns.Where(c => c.Value.Name == "Team").Select(c => c.Value).First().Index;
                var teamName = Convert.ToString(fields[nameIndex]);
                CorrespondingSportScoreFile.AllRecords.Add(teamName, fields);
            }
            catch
            {
                logger.Log("Some issue with parsing the sport scores file");
            }
        }

        private void FillAllColumnsData()
        {
            if (this.columnsNode != null)
                foreach (XmlNode colNode in this.columnsNode.ChildNodes)
                {
                    var attrs = colNode.Attributes.Cast<XmlAttribute>();

                    string colName = attrs.Where(a => a.Name == "Name").Select(a => a.Value).First();
                    string colHeaderName = attrs.Where(a => a.Name == "Header").Select(a => a.Value).First();
                    string colType = attrs.Where(a => a.Name == "Type").Select(a => a.Value).First();
                    string colIndex = attrs.Where(a => a.Name == "Index").Select(a => a.Value).First();

                    FileColumn col = new FileColumn();
                    col.Name = colName;
                    col.Header = colHeaderName;
                    col.Type = colType;
                    col.Index = Convert.ToInt32(colIndex);

                    CorrespondingSportScoreFile.AllColumns.Add(colName, col);
                }
        }

        private void FillAllRulesData()
        {
            if (this.rulesNode != null)
                foreach (XmlNode ruleNode in this.rulesNode.ChildNodes)
                {
                    var attrs = ruleNode.Attributes.Cast<XmlAttribute>();

                    string colName = attrs.Where(a => a.Name == "Name").Select(a => a.Value).First();
                    string col1 = attrs.Where(a => a.Name == "Column1").Select(a => a.Value).First();
                    string col2 = attrs.Where(a => a.Name == "Column2").Select(a => a.Value).First();
                    string operatorString = attrs.Where(a => a.Name == "Operator").Select(a => a.Value).First();


                    AnySportRule rule = AnySportRuleFactory.GetSportRule(CorrespondingSportScoreFile);
                    rule.Name = colName;
                    rule.Column1 = col1;
                    rule.Column2 = col2;
                    rule.Operation = (Operation)Enum.Parse(typeof(Operation), operatorString);

                    CorrespondingSportScoreFile.AllRules.Add(colName, rule);
                }
        }

        #endregion

    }
}
