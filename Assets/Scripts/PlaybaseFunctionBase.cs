using PlayFab;
using PlayFab.SharedModels;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayFabfunctionBase : MonoBehaviour
{
    public UnityAction<PlayFabError> onError;
    public UnityAction<string> onSucceed;
    public virtual void DoFunction()
    {

    }
}
