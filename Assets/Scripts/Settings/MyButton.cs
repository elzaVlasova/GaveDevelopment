using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MyButton : MonoBehaviour {
	public UnityEvent signalOnClick = new UnityEvent();
	public MyButton pauseButton, playButton, settingsButton;

	// Use this for initialization
	void Start () {
		if (playButton != null) {
			playButton.signalOnClick.AddListener (this.onPlay);
		}
	}

	public void onClick(){
		this.signalOnClick.Invoke ();
		Debug.Log ("PlayButton");
	}

	void onPlay(){
		SceneManager.LoadScene ("ChooseLevel");
	}
}

