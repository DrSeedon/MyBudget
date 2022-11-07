using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MainController : MonoBehaviour
{
    void Start()
    {
        StartParse();
    }

    public void StartParse()
    {
        GetData();
        UIController.Instance.ShowDatas(DataController.Instance.budgetData);
    }

    private void GetData()
    {
        if (DataController.Instance.ExistData())
            DataController.Instance.LoadGame();
        else
        {
            ExcelParser.Parse();
            DataController.Instance.SaveGame();
        }
    }

}
