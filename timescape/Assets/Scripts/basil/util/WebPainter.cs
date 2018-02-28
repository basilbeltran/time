using UnityEngine;
using System.Collections;
using PygmyMonkey.WebRequest;
using System;

public class WebPainter : MonoBehaviour
{
	[SerializeField] public string m_Url = "http://apod.nasa.gov/apod/image/9712/orionfull_jcc_big.jpg";
	 private float m_TimeOut = 2.5f;
	 private Renderer m_QuadRenderer;

    void Start(){
        m_QuadRenderer = gameObject.GetComponent<Renderer>();
        m_QuadRenderer.material.mainTexture = null;
        DownloadTextureCallback();
    }

	private void BeforeRequestStart()
	{
		m_QuadRenderer.material.mainTexture = null;
        Debug.Log("Starting web request..." +m_Url);
	}

	// First method
	private IEnumerator DownloadTextureCoroutine()
	{
		WebRequest request = new WebRequest(m_Url, m_TimeOut);
		yield return StartCoroutine(request);
		OnRequestDone(request);
	}

	// Second method
	private void DownloadTextureCallback()
	{
		WebRequest.Request(m_Url, m_TimeOut, this, (WebRequest request) =>
		{
			OnRequestDone(request);
		});
	}

	// Delay
	private void DownloadTextureDelay()
	{
		WebRequest.Request(m_Url, m_TimeOut, 5.0f, this, (WebRequest request) =>
		{
			OnRequestDone(request);
		});
	}

	private void OnRequestDone(WebRequest request)
	{
		Debug.Log("State: " + request.GetState());

		switch (request.GetState())
		{
		case WebRequest.State.DONE:
			Debug.Log("Downloaded texture in: " + request.elapsedDuration + " seconds");
			m_QuadRenderer.material.mainTexture = request.www.texture;
			break;

		case WebRequest.State.TIMEOUT:
			Debug.LogWarning("The request timed out! (elapsedDuration: " + request.elapsedDuration + ")");
			break;

		case WebRequest.State.ERROR:
			Debug.LogError("An error occured (elapsedDuration: " + request.elapsedDuration + "): " + request.www.error);
			break;
		}
	}
}
