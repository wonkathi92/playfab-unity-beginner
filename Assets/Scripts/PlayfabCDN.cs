using PlayFab;
using PlayFab.ClientModels;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayfabCDN : PlayFabfunctionBase
{
    public override void DoFunction()
    {
        PlayFabClientAPI.GetContentDownloadUrl(new PlayFab.ClientModels.GetContentDownloadUrlRequest()
        {
            HttpMethod = "GET",
            Key = "playfab_img"
        }, OnSuccess,
        OnFailure);
    }
    private void OnSuccess(GetContentDownloadUrlResult result)
    {
        onSucceed?.Invoke(result.URL);
    }
    private void OnFailure(PlayFabError error)
    {
        onError?.Invoke(error);
    }
}
