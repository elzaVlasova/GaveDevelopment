using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class SoundManager{

	public static bool IsSoundOn
	{
		get {
			return PlayerPrefs.GetInt("sound", 1) == 1;
		}
		set {
			PlayerPrefs.SetInt ("sound", value ? 1 : 0);
		}
	}

	public static bool IsMusicOn
	{
		get {
			return PlayerPrefs.GetInt("music", 1) == 1;
		}
		set {
			PlayerPrefs.SetInt ("music", value ? 1 : 0);
		}
	}

}
