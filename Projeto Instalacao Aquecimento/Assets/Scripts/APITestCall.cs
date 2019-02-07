using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class APITestCall : MonoBehaviour {

    // https ://resttesttest.com 
    private const string URL = "https://httpbin.org/get"; //n3k.ca
    public Text responseText;

    public void Request()
    {

        WWW request = new WWW(URL);
        StartCoroutine(OnResponse(request));
    }

    private IEnumerator OnResponse(WWW req)
    {
        yield return req;
        Debug.Log(req.text);
        responseText.text = req.text;
    }

}

