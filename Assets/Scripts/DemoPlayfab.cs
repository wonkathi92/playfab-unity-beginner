using PlayFab;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DemoPlayfab : MonoBehaviour
{
    [SerializeField] Transform container;
    [SerializeField] Text txtError;
    List<PlayFabfunctionBase> functions = new List<PlayFabfunctionBase>();
    private void Awake()
    {
        var _functions = container.GetComponentsInChildren<PlayFabfunctionBase>();
        functions.AddRange(_functions);
        foreach(var f in functions)
        {
            f.onError = OnError;
            f.onSucceed = OnActionSucceed;
        }
    }
    private void OnError(PlayFabError error)
    {
        txtError.color = Color.red;
        txtError.text = error.GenerateErrorReport();
    }
    private void OnActionSucceed(string message)
    {
        txtError.color = Color.green;
        txtError.text = message;
    }
}
