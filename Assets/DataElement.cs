using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DataElement : MonoBehaviour
{
    public TMP_Text TextDateOperation;
    public TMP_Text TextCategory;
    public TMP_Text TextOperationName;
    public TMP_Text TextAmount;
    public GameObject parent;
    
    public void SetData(DataController.ProcedureData data)
    {
        TextDateOperation.text = data.DateOperation.ToString();
        TextDateOperation.text += " ";
        TextCategory.text = data.Category;
        TextCategory.text += " ";
        TextOperationName.text = data.OperationName;
        TextOperationName.text += " ";
        TextAmount.text = data.Amount.ToString();
        TextAmount.text += " ";
        //StartCoroutine(UpdateLayoutGroup());
    }

    IEnumerator UpdateLayoutGroup()
    {
        parent.SetActive(false);
        yield return new WaitForEndOfFrame();
        parent.SetActive(true);
        yield return new WaitForEndOfFrame();
        parent.SetActive(false);
        yield return new WaitForEndOfFrame();
        parent.SetActive(true);
        yield return new WaitForEndOfFrame();
        parent.SetActive(false);
        yield return new WaitForEndOfFrame();
        parent.SetActive(true);
    }

    private void LateUpdate()
    {
    }
}
