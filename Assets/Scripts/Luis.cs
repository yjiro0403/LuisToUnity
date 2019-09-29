using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.Networking;

public class Luis : MonoBehaviour {
    InputField inputField;
    string inputValue;
    public string mystr = "Failed get Request";
    string requestMessage = "null";



    // Use this for initialization
    void Start () {
        inputField = GetComponent<InputField>();
    }

    public void InputLogger()
    {
        inputValue = inputField.text;
        Debug.Log("Input is : " + inputValue);


        StartCoroutine(GetTexture());
    }

    public IEnumerator GetTexture()
    {
        UnityWebRequest www = UnityWebRequest.Get("https://westus.api.cognitive.microsoft.com/luis/v2.0/apps/9f84188a-903e-4b91-8b32-c0833c36950c?subscription-key=3d17803e340a4429adbf079daf6b50de&verbose=true&timezoneOffset=0&q=" + WWW.EscapeURL(inputValue));

        AsyncOperation checkAsync = www.Send();
        while (!checkAsync.isDone) ;
        //Debug.Log("Request Async is " + checkAsync.isDone);

        if (www.isError)
        {
            mystr = www.error;  //unknown error
            Debug.Log(www.error);
        }
        else
        {
            var json = www.downloadHandler.text;
            var x = JsonUtility.FromJson<JsonFunc<Queries>>(json);
            Debug.Log("Luis.cs Get data : " + json);
            Debug.Log("Received Query: " + x.query);
            Debug.Log("Received Intent: " + x.topScoringIntent.intent);
            Debug.Log("Received Score: " + x.topScoringIntent.score);


            mystr = x.topScoringIntent.intent;
        }

        inputField.text = "";
        inputField.ActivateInputField();

        yield return null;
    }
}
