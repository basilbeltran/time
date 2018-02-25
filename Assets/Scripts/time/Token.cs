//using System;
//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using UnityEngine.Networking;
////using Google.Apis.Auth.OAuth2;
////using Google.Apis.Calendar.v3;
////using Google.Apis.Calendar.v3.Data;
////using Google.Apis.Services;
////using Google.Apis.Util.Store;
////using System.Threading.Tasks;
////using Google.Apis.Discovery.v1;
////using Google.Apis.Discovery.v1.Data;
////using Google.Apis.Services;

//public class Token : MonoBehaviour {
//    [SerializeField] string client_id;
//    [SerializeField] string client_secret;

//    WWW www;

//	// Use this for initialization
//	void Start () {
		
//	}
	
//	// Update is called once per frame
//	void Update () {
		
//	}

//    [Serializable]
//    public class TokenClassName
//    {
//        public string access_token;
//    }

//    IEnumerator GetAccessTokenWWW()
//    {
//        var url = "https://www.googleapis.com/auth/calendar.readonly";
//        var form = new WWWForm();
//        form.AddField("grant_type", "client_credentials");
//        form.AddField("client_id", client_id);
//        form.AddField("client_secret", client_secret);

//        www = new WWW(url, form);

//        //wait for request to complete
//        yield return www;

//        //and check for errors
//        if (String.IsNullOrEmpty(www.error))
//        {
//            string resultContent = www.text;
//            Debug.Log(resultContent);
//            TokenClassName json = JsonUtility.FromJson<TokenClassName>(resultContent);
//            Debug.Log("WWWToken: " + json.access_token);
//        }
//        else
//        {
//            //something wrong!
//            Debug.Log("WWW Error: " + www.error);
//        }
//    }

//    private static IEnumerator GetAccessTokenUWR(Action<string> result)
//    {
//        //Dictionary<string, string> content = new Dictionary<string, string>();
//        ////Fill key and value
//        //content.Add("grant_type", "client_credentials");
//        //content.Add("client_id", "login-secret");
//        //content.Add("client_secret", "secretpassword");

//        //UnityWebRequest www = UnityWebRequest.Post("https://someurl.com//oauth/token", content);
//        ////Send request
//        //yield return www.Send();

//        //if (!www.isNetworkError)
//        //{
//        //    string resultContent = www.downloadHandler.text;
//        //    TokenClassName json = JsonUtility.FromJson<TokenClassName>(resultContent);

//        //    //Return result
//        //    result(json.access_token);
//        //    Debug.Log("WWWToken: " + json.access_token);

//        //}
//        //else
//        //{
//        //    //Return null
//        //    result("");
//        //}
//    }


//}
