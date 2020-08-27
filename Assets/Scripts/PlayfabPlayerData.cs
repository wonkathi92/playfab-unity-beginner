using PlayFab;
using PlayFab.ClientModels;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayfabPlayerData : PlayFabfunctionBase
{
    [SerializeField] GameObject Panel;
    [SerializeField] InputField inputKey, inputValue;

    public override void DoFunction()
    {
        Panel.gameObject.SetActive(true);
    }

    public void OnSetData()
    {
        string key = inputKey.text;
        string value = inputValue.text;
        Panel.gameObject.SetActive(false);
        var data = new Dictionary<string, string>()
        {
            {key, value },
        };
        var request = new UpdateUserDataRequest
        {
            Data = data
        };
        PlayFabClientAPI.UpdateUserData(request, OnSuccess, OnFailure);
    }
    private void OnSuccess(UpdateUserDataResult result)
    {
        var request = new GetUserDataRequest()
        {
            Keys = new List<string>()
            {
                inputKey.text
            }
        }; 
        PlayFabClientAPI.GetUserData(request, OnGetDataSuccess, OnFailure);
    }
    void OnGetDataSuccess(GetUserDataResult result)
    {
        onSucceed?.Invoke($"Set & Get PlayerData successful: {inputKey.text} - {result.Data[inputKey.text].Value}");
    }
    private void OnFailure(PlayFabError error)
    {
        onError?.Invoke(error);
    }
}
