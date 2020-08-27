using PlayFab;
using PlayFab.ClientModels;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayfabData : PlayFabfunctionBase
{
    string tag = "battle_per_day";
    public override void DoFunction()
    {
        var request = new GetTitleDataRequest()
        {
            Keys = new List<string>() { tag }
        };
        PlayFabClientAPI.GetTitleData(request, OnLoginSuccess, OnLoginFailure);
    }
    private void OnLoginSuccess(GetTitleDataResult result)
    {
        if (result.Data.ContainsKey(tag))
        {
            onSucceed?.Invoke($"{tag} : {result.Data[tag]}");
        } else
        {
            onSucceed?.Invoke($"Can't find {tag}");
        }
    }
    private void OnLoginFailure(PlayFabError error)
    {
        onError?.Invoke(error);
    }
}
