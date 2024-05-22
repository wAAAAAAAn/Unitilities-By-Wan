using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Networking;
using UnityCommunity.UnitySingleton;

public class NetworkManager : MonoSingleton<NetworkManager>
{
    public void Send<TReq, TRes>(TReq requestData, Action<TRes> _callback)
        where TReq : ProtocolBase
        where TRes : ProtocolBase, new()
    {
        StartCoroutine(Co_Send(requestData, _callback));
    }

    private IEnumerator Co_Send<TReq, TRes>(TReq requestData, Action<TRes> _callback)
        where TReq : ProtocolBase
        where TRes : ProtocolBase, new()
    {
        string url = requestData.RequestURL();
        string jsonData = requestData.ToJson();

        UnityWebRequest req = new UnityWebRequest(url, UnityWebRequest.kHttpVerbPOST);
        byte[] bodyRaw = System.Text.Encoding.UTF8.GetBytes(jsonData);
        req.uploadHandler = new UploadHandlerRaw(bodyRaw);
        req.downloadHandler = new DownloadHandlerBuffer();
        req.SetRequestHeader("Content-Type", "application/json");

        yield return req.SendWebRequest();

        UnityWebRequest.Result result = req.result;

        if (result == UnityWebRequest.Result.Success)
        {
            Debug.Log($"NetworkManager :: Success :: {req.downloadHandler.text}");
            TRes responseProtocol = new TRes();
            responseProtocol.FromJson(req.downloadHandler.text);

            if (_callback != null)
            {
                _callback(responseProtocol);
            }
        }
        else if (result == UnityWebRequest.Result.ConnectionError ||
                 result == UnityWebRequest.Result.DataProcessingError ||
                 result == UnityWebRequest.Result.ProtocolError)
        {
            Debug.LogError($"NetworkManager :: Error :: {req.error}");
            Debug.LogError($"Response: {req.downloadHandler.text}");
        }
    }

}
