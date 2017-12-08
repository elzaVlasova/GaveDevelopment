using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Setting : MonoBehaviour {
	bool is_sound_on = true;
	bool is_music_on = true;

	public Sprite soundOnSprite, soundOffSprite, musicOnSprite, musicOffSprite;
	public GameObject soundButton, musicButton;

	void Start(){
		is_sound_on = PlayerPrefs.GetInt("sound", 1) == 1;
		SoundManager.Instanse.setSoundOn (is_sound_on);
		is_music_on = PlayerPrefs.GetInt("music", 1) == 1;
		SoundManager.Instanse.setMusicOn (is_music_on);

		UI2DSprite spriteSound = soundButton.GetComponent<UI2DSprite>();
		spriteSound.sprite2D = is_sound_on ? soundOnSprite : soundOffSprite;
		UI2DSprite spriteMusic = musicButton.GetComponent<UI2DSprite>();
		spriteMusic.sprite2D = is_music_on ? musicOnSprite : musicOffSprite;
	}

	void Update(){
		UI2DSprite spriteSound = soundButton.GetComponent<UI2DSprite>();
		spriteSound.sprite2D = is_sound_on ? soundOnSprite : soundOffSprite;
		UI2DSprite spriteMusic = musicButton.GetComponent<UI2DSprite>();
		spriteMusic.sprite2D = is_music_on ? musicOnSprite : musicOffSprite;
	}

	public void onCloseClick(){
		//Destroy (this.gameObject);
		this.gameObject.SetActive(false);
	}

	public void onSoundClick() {
		is_sound_on = !is_sound_on ;
		SoundManager.Instanse.setSoundOn(is_sound_on);

		UI2DSprite sprite = soundButton.GetComponent<UI2DSprite>();
		sprite.sprite2D = is_sound_on? soundOnSprite:soundOffSprite;
	}

	public void onMusicClick() {
		is_music_on = !is_music_on;
		LevelController.current.musicSetting(is_music_on);


		UI2DSprite sprite = musicButton.GetComponent<UI2DSprite>();
		sprite.sprite2D = is_music_on ? musicOnSprite : musicOffSprite;
	}
}

