using PlayFab;
using PlayFab.ClientModels;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayfabLinkAccount : PlayFabfunctionBase
{
    public override void DoFunction()
    {
        var request = new LinkCustomIDRequest
        {
            CustomId = SystemInfo.deviceUniqueIdentifier
        };
        PlayFabClientAPI.LinkCustomID(request, OnSuccess, OnFailure);
    }
    private void OnSuccess(LinkCustomIDResult result)
    {
        onSucceed?.Invoke("Link account completed");
    }
    private void OnFailure(PlayFabError error)
    {
        onError?.Invoke(error);
    }
}
