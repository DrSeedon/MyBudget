using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using static DataController;

public class UIController : StaticInstance<UIController>
{
    public TMP_Text Text;
    public void ShowDatas()
    {
        Text.text = "";
        budgetData.ProcedureDatas.Sort((x, y) => x.Amount.CompareTo(y.Amount));
        foreach (var procedure in budgetData.ProcedureDatas)
        {
            Text.text +=
                $"{procedure.DateOperation} {procedure.Category} {procedure.OperationName} {procedure.Amount} \n";
        }
    }
}
