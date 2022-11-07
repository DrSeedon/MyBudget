using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;

public class UIController : StaticInstance<UIController>
{
    public ElementManager ElementManager;

    public void ShowDatas(DataController.BudgetData instanceBudgetData)
    {
        ElementManager.ShowDatas(instanceBudgetData);
    }

}
