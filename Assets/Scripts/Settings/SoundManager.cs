using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager{
	public static SoundManager Instanse = new SoundManager ();
	bool is_sound_on = true;
	bool is_music_on = true;


	public bool IsSoundOn(){
		return is_sound_on;
	}

	public void setSoundOn(bool val){
		this.is_sound_on = val;
		PlayerPrefs.SetInt ("sound", this.is_sound_on ? 1 : 0);
		PlayerPrefs.Save ();
	}

	public bool IsMusicOn(){
		return is_sound_on;
	}

	public void setMusicOn(bool val){
		this.is_sound_on = val;
		PlayerPrefs.SetInt ("music", this.is_music_on ? 1 : 0);
		PlayerPrefs.Save ();
	}


	void Start(){
		//is_sound_on = PlayerPrefs.GetInt ("sound", 1) == 1;
		//is_music_on = PlayerPrefs.GetInt ("music", 1) == 1;
	}

	public void onSoundClick() {
		is_sound_on = !is_sound_on ;
	}

	public void onMusicClick() {
		is_music_on = !is_music_on;
	}

}
