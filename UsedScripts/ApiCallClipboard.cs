using System.Collections;
using System;
using UnityEngine;
using Newtonsoft.Json;
using TMPro;
using UnityEngine.Networking;

public class ApiCallClipboard : MonoBehaviour
{

    public TextMeshProUGUI SetupText;
    public TextMeshProUGUI PunchlineText;
    
    public class Joke
    {
        public string type { get; set; }
        public string setup { get; set; }
        public string punchline { get; set; }
        public int id { get; set; }
    }
    public void OnRefresh()
    {
        GetNewJoke();
    }

    public void GetNewJoke()
    {
        StartCoroutine(GetRequest("https://official-joke-api.appspot.com/random_joke"));
    }

    

    IEnumerator GetRequest(String Uri)
    {
        using (UnityWebRequest webRequest = UnityWebRequest.Get(Uri))
        {
            yield return webRequest.SendWebRequest();

            switch (webRequest.result)
            {
                case UnityWebRequest.Result.ConnectionError:
                case UnityWebRequest.Result.DataProcessingError:
                    Debug.LogError(String.Format("Something went wrong: {0}", webRequest.error));
                    break;


                case UnityWebRequest.Result.Success:
                    Joke joke = JsonConvert.DeserializeObject<Joke>(webRequest.downloadHandler.text);
                    SetupText.text = joke.setup;
                    PunchlineText.text = joke.punchline;
                    break;
            }
        }
    }

}