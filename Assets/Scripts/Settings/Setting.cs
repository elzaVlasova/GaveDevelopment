using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Setting : MonoBehaviour {

	public GameObject soundButtonOn;
	public GameObject musicButtonOn;
	public GameObject soundButtonOff; 
	public GameObject musicButtonOff;


	public void onCloseClick(){
		//Destroy (this.gameObject);
		this.gameObject.SetActive(false);
	}

	void Start()
	{
		ToggleSoundButton ();
		ToggleMusicButton ();
	}

	public void onSoundClick() {
		SoundManager.IsSoundOn = !SoundManager.IsSoundOn;
		ToggleSoundButton ();
	}

	private void ToggleSoundButton()
	{
		soundButtonOn.SetActive (SoundManager.IsSoundOn);
		soundButtonOff.SetActive (!SoundManager.IsSoundOn);
	}

	private void ToggleMusicButton()
	{
		musicButtonOn.SetActive (SoundManager.IsMusicOn);
		musicButtonOff.SetActive (!SoundManager.IsMusicOn);
	}


	public void onMusicClick() {
		SoundManager.IsMusicOn = !SoundManager.IsMusicOn;
		LevelController.current.musicSetting(SoundManager.IsMusicOn);
		ToggleMusicButton ();
	}
}

