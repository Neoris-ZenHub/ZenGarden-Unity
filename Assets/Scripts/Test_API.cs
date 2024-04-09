using UnityEngine;
using UnityEngine.Networking;
using System.Collections;
using System.Collections.Generic; // Add this line for List<>

public class ApiRequest : MonoBehaviour
{
    // URL of your local API endpoint
    string apiUrl = "http://localhost:your_port_number/your_endpoint";

    void Start()
    {
        StartCoroutine(GetRequest(apiUrl));
        StartCoroutine(PostRequest(apiUrl, "Your POST Data"));
    }

    IEnumerator GetRequest(string url)
    {
        using (var request = UnityWebRequest.Get(url))
        {
            yield return request.SendWebRequest();

            if (request.result != UnityWebRequest.Result.Success)
            {
                Debug.LogError("Error: " + request.error);
            }
            else
            {
                Debug.Log("GET Response: " + request.downloadHandler.text);
                // You can process the response here
            }
        }
    }

    IEnumerator PostRequest(string url, string postData)
    {
        List<IMultipartFormSection> formData = new List<IMultipartFormSection>();
        formData.Add(new MultipartFormDataSection("key", "value"));

        using (var request = UnityWebRequest.Post(url, formData))
        {
            yield return request.SendWebRequest();

            if (request.result != UnityWebRequest.Result.Success)
            {
                Debug.LogError("Error: " + request.error);
            }
            else
            {
                Debug.Log("POST Response: " + request.downloadHandler.text);
                // You can process the response here
            }
        }
    }
}
