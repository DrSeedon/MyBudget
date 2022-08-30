using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class DataController
{
    public class BudgetData
    {
        public List<ProcedureData> ProcedureDatas = new List<ProcedureData>();
    }

    public static BudgetData budgetData = new BudgetData();

    public class ProcedureData
    {
        public DateTime DateOperation;
        public DateTime DateProcessing;
        public string AuthorizationCode;
        public string Category;
        public string OperationName;
        public double Amount;
        public double AccountBalance;
    }
    
    [Serializable]
    public class SaveData
    {
        public BudgetData BudgetData;
    }

    private static SaveData _saveData = new SaveData();

    private const string NameFile = "save.json";

    public static void SaveGame()
    {
        ResetData();
        _saveData.BudgetData = budgetData;
        FileIOUtility.WriteToJson(NameFile, _saveData);
    }

    public static void LoadGame()
    {
        var gameData = (SaveData) FileIOUtility.ReadFromJson<SaveData>(NameFile);

        if (gameData != null)
            budgetData = _saveData.BudgetData;
    }

    static void ResetData()
    {
        if (File.Exists(Application.streamingAssetsPath + $"/{NameFile}"))
            File.Delete(Application.streamingAssetsPath + $"/{NameFile}");
    }

    public static bool ExistData()
    {
        return File.Exists(Application.streamingAssetsPath + $"/{NameFile}");
    }
}