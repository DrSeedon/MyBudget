using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static DataController;

public class MainController : MonoBehaviour
{
    void Start()
    {
        GetData();
        UIController.Instance.ShowDatas();
    }

    private void GetData()
    {
        if (ExistData())
            LoadGame();
        else
        {
            ExcelParser.Parse();
            SaveGame();
        }
    }

}
