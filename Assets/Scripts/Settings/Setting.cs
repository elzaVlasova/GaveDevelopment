using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Setting : MonoBehaviour {
	bool is_sound_on = true;
	bool is_music_on = true;

	void Start(){
		is_sound_on = PlayerPrefs.GetInt("sound", 1) == 1;
		SoundManager.Instanse.setSoundOn (is_sound_on);
		is_music_on = PlayerPrefs.GetInt("music", 1) == 1;
		SoundManager.Instanse.setMusicOn (is_music_on);
	}

	void Update(){
		
	}

	public void onCloseClick(){
		Destroy (this.gameObject);
	}

	public void onSoundClick() {
		is_sound_on = !is_sound_on ;
		SoundManager.Instanse.setSoundOn(is_sound_on);
	}

	public void onMusicClick() {
		is_music_on = !is_music_on;
		SoundManager.Instanse.setMusicOn(is_music_on);
	}
}

