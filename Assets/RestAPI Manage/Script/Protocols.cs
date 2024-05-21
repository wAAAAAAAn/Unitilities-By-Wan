using System;
using Newtonsoft.Json;
using UnityEngine;

#region ProtocolBase
public interface IProtocol
{
    string ToJson();
    void FromJson(string jsonData);
    string RequestURL();
}

[Serializable]
public abstract class ProtocolBase : IProtocol
{
    [JsonIgnore]
    public string ServerURL = "";
    [JsonIgnore]
    public string Example1 = "Example1";

    [JsonIgnore]
    protected string URL;

    public string ToJson()
    {
        return JsonConvert.SerializeObject(this);
    }

    public void FromJson(string jsonData)
    {
        JsonConvert.PopulateObject(jsonData, this);
    }

    public abstract string RequestURL();
}
#endregion



[Serializable]
public class ImageToResult_Request_Protocol : ProtocolBase
{
    public string imageBase64;
    public string caption;

    public override string RequestURL()
    {
        return StringTool.ConnectString(ServerURL, Example1);
    }
}

[Serializable]
public class ImageToResult_Response_Protocol : ProtocolBase
{
    public string caption;

    public override string RequestURL()
    {
        return "";
    }
}



