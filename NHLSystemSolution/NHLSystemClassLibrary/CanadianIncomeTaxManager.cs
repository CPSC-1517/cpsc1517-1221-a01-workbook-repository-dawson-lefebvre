using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace NHLSystemClassLibrary
{
    public class CanadianIncomeTaxManager
    {
        public List<CanadianIncomeTaxData> CanadianIncomeTaxData(List<String> lines)
        {
            List<CanadianIncomeTaxData> dataList = new List<CanadianIncomeTaxData>();
            foreach (String line in lines)
            {
                string[] lineSplit = line.Split(",");
                string regionAb = lineSplit[0];
                string regionName = lineSplit[1];
                int taxYear = lineSplit[2];

                dataList.Add(new CanadianIncomeTaxData());
            }
            return dataList;
        }
        public List<String> LoadFromCSVFile(string csvFilePath)
        {
            List<String> list = new List<String>();
            using (StreamReader reader = new StreamReader(csvFilePath))
            {
                string currentLine;
                reader.ReadLine();
                while ((currentLine = reader.ReadLine()) != null)
                {
                    list.Add(currentLine);
                }
            }
            return list;
        }
    }
}
