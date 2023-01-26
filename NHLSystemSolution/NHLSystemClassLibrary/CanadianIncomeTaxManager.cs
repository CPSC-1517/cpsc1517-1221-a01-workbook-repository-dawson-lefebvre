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
                CanadianIncomeTaxData data = new CanadianIncomeTaxData();
                string[] lineSplit = line.Split(",");
                data.RegionAbbreviation = lineSplit[0];
                data.RegionName = lineSplit[1];
                data.TaxYear = int.Parse(lineSplit[2]);
                data.StartingIncome = decimal.Parse(lineSplit[4]);
                data.EndingIncome = decimal.Parse(lineSplit[5]);
                data.TaxRate = double.Parse(lineSplit[6]);
                data.BaseTaxAmount = decimal.Parse(lineSplit[7]);
                
                dataList.Add(data);
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
