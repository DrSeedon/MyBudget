using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ElementManager : PoolerBase<DataElement>
{
    public TMP_Text loadedText;
    public DataElement prefabDataElement;
    public GameObject parentDataElement;
    public List<DataElement> listElements;

    private void Awake()
    {
        InitPool(prefabDataElement, 1000, 20000);
    }
    protected override DataElement CreateSetup()
    {
        return Instantiate(prefabDataElement, parentDataElement.transform);
    }
    public void ShowDatas(DataController.BudgetData data)
    {
        EraseAll();
        int count = 0;
        foreach (var procedureData in data.ProcedureDatas)
        {
            var obj = Get();
            obj.gameObject.SetActive(true);
            var dataElement = obj.GetComponent<DataElement>();
            dataElement.SetData(procedureData);

            listElements.Add(obj);
            count++;
            loadedText.text = $"Loaded: {count} / {data.ProcedureDatas.Count}";
        }
    }

    public void FilterByAmount()
    {
        var data = DataController.Instance.budgetData;
        data.ProcedureDatas.Sort((x, y) => x.Amount.CompareTo(y.Amount));
        ShowDatas(data);
    }
    public void FilterByDateOperation()
    {
        var data = DataController.Instance.budgetData;
        data.ProcedureDatas.Sort((x, y) => x.DateOperation.CompareTo(y.DateOperation));
        ShowDatas(data);
    }
    
    public void FilterByOperationName()
    {
        var data = DataController.Instance.budgetData;
        data.ProcedureDatas.Sort((x, y) => String.Compare(x.OperationName, y.OperationName, StringComparison.Ordinal));
        ShowDatas(data);
    }
    public void FilterByCategory()
    {
        var data = DataController.Instance.budgetData;
        data.ProcedureDatas.Sort((x, y) => String.Compare(x.Category, y.Category, StringComparison.Ordinal));
        ShowDatas(data);
    }

    private void EraseAll()
    {
        foreach (var element in listElements)
        {
            Release(element);
        }
        listElements.Clear();
    }
    
}
