using System.IO;
using ExcelDataReader;
using UnityEngine;

public static class ExcelParser
{
    public static void Parse()
    {
        string nameDir = Application.streamingAssetsPath + "/sourse.xlsx";

        using (var stream = File.Open(nameDir, FileMode.Open, FileAccess.Read))
        {
            using (var reader = ExcelReaderFactory.CreateReader(stream))
            {
                int row = 0;
                do
                {
                    reader.Read();
                    while (reader.Read())
                    {
                        if (reader.GetValue(0) == null)
                            return;
                        var procedureData = new DataController.ProcedureData
                        {
                            DateOperation = reader.GetDateTime(0),
                            DateProcessing = reader.GetDateTime(1),
                            AuthorizationCode = reader.GetString(2),
                            OperationName = reader.GetString(3),
                            Category = reader.GetString(4),
                            Amount = reader.GetDouble(5),
                            AccountBalance = reader.GetDouble(8)
                        };
                        DataController.budgetData.ProcedureDatas.Add(procedureData);
                        row++;
                    }
                } while (reader.NextResult());
            }
        }
    }
}