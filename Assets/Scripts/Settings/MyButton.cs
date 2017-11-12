using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;
using UnityEngine;

public class MyButton : MonoBehaviour {
	public UnityEvent signalOnClick = new UnityEvent();
	public MyButton pauseButton, playButton, settingsButton;

	// Use this for initialization
	void Start () {
		playButton.signalOnClick.AddListener (this.onPlay);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void onClick(){
		this.signalOnClick.Invoke ();
	}

	void onPlay(){
	}
}

