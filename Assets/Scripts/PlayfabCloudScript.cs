using PlayFab;
using PlayFab.ClientModels;
using PlayFab.PfEditor.Json;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayfabCloudScript : PlayFabfunctionBase
{
    public override void DoFunction()
    {
        PlayFabClientAPI.ExecuteCloudScript(new ExecuteCloudScriptRequest()
        {
            FunctionName = "multiplyBattle", // Arbitrary function name (must exist in your uploaded cloud.js file)
            GeneratePlayStreamEvent = true, // Optional - Shows this event in PlayStream,
            FunctionParameter = new {number = 10}
        }, OnSuccess, OnFailure);
    }
    private void OnSuccess(ExecuteCloudScriptResult result)
    {
        if(result.FunctionResult == null)
        {
            onSucceed?.Invoke($"Result null");
            return;
        }
        var jsonResult = JsonWrapper.DeserializeObject<JsonObject>(result.FunctionResult.ToString());
        object configValue;
        jsonResult.TryGetValue("result", out configValue);
        onSucceed?.Invoke($"Config value: {configValue}");
    }
    private void OnFailure(PlayFabError error)
    {
        onError?.Invoke(error);
    }
}
