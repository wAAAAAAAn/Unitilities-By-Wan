using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class SendTest : MonoBehaviour
{
    public Sprite TestSprite;
    // Start is called before the first frame update
    void Start()
    {
        string Base64 = Img2Base64.Sprite2Base64(TestSprite);

        // For extractPrompt protocol
        ImageToResult_Request_Protocol extractPromptRequest = new ImageToResult_Request_Protocol
        {
           imageBase64 = StringTool.ConnectString("data:image/png;base64,", Base64),
           caption = "userID",
        };

        NetworkManager.Instance.Send(extractPromptRequest, (ImageToResult_Response_Protocol response) =>
        {
            Debug.Log("Response received");
            // Handle the response
            Debug.Log(response.caption);
        });
    }

    

}
