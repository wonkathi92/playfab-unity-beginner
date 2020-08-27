using PlayFab;
using PlayFab.ClientModels;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayfabLogin : PlayFabfunctionBase
{
    public override void DoFunction()
    {
        var request = new LoginWithCustomIDRequest
        {
            CustomId = "Techtalk-28August",
            CreateAccount = true
        };
        PlayFabClientAPI.LoginWithCustomID(request, OnSuccess, OnFailure);
    }
    private void OnSuccess(LoginResult result)
    {
        ShareData.PlayFabId = result.PlayFabId;
        onSucceed?.Invoke("Congratulations, you made your first successful API call!");
    }
    private void OnFailure(PlayFabError error)
    {
        onError?.Invoke(error);
    }
}
