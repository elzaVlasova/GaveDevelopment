using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelController : MonoBehaviour {
	public static LevelController current;
	Vector3 startingPosition;

	public bool rabbitIsDead = false;

	public UILabel coinsLabel;
	public UILabel fruitsLabel;
	public GameObject settingsPrefab;
	public GameObject looseWindow;
	public GameObject winnerWindow;
	public GameObject winWindow;
	public GameObject settingdWindow;

	public AudioClip music = null;
	AudioSource musicSourse = null;

	public AudioClip looseMusic = null;
	AudioSource looseMusicSourse = null;

	public AudioClip winMusic = null;
	AudioSource winMusicSourse = null;

	int coins;
	int fruits;
	int crystals;
	int rabbitLifes;

	private List <Crystals.Type> crystalsCollected;
	private List <Fruits.Type> fruitsCollected;


	void Awake(){
		current = this;

	}

	void Start(){
//		coinsLabel.text = "0000";
//		fruitsLabel.text = "0";
		musicSourse = gameObject.AddComponent<AudioSource>();
		musicSourse.clip = music;
		musicSourse.loop = true;
		musicSourse.Play ();

		looseMusicSourse = gameObject.AddComponent<AudioSource>();
		looseMusicSourse.clip = looseMusic;

		winMusicSourse = gameObject.AddComponent<AudioSource>();
		winMusicSourse.clip = winMusic;

		crystalsCollected = new List <Crystals.Type>();
		fruitsCollected = new List <Fruits.Type>();
		rabbitLifes = 3;
        //winnerWindow.SetActive (true);
		//looseWindow.SetActive (true);
	}


	public void musicSetting(bool is_music_on){
		if (is_music_on) {
			musicSourse.Play ();
		} else { musicSourse.Stop ();
		}
	}


	public void onPauseClick(){
		//GameObject parent = UICamera.first.transform.parent.gameObject;
		//GameObject obj = NGUITools.AddChild(parent, settingsPrefab);
		//Setting popup = obj.GetComponent<Setting>();
		settingdWindow.SetActive(true);
	}

	public void onPlayClick(){
		SceneManager.LoadScene ("ChooseLevel");
	}

	public void onReplayClickLevel1(){
		SceneManager.LoadScene ("Level1");
		rabbitLifes = 3;
		HealthUI.current.RenewPanel ();
	}

	public void onReplayClickLevel2(){
		SceneManager.LoadScene ("New Scene");
		rabbitLifes = 3;
	}

	public void onLoosePopup(){
		looseWindow.SetActive (true);
		if (SoundManager.Instanse.IsSoundOn ()) {
			looseMusicSourse.Play ();
		}
	}


	public void onWinPopup(GameObject winWindow, int level){
		this.winWindow = winWindow;
		SettingsWinWindow ();
		if (SoundManager.Instanse.IsSoundOn ()) {
			winMusicSourse.Play ();
		}
		winWindow.SetActive (true);
		GameStats.AddCoins (coins);
		if (crystalsCollected.Count == 3) {
			Debug.Log ("Capacity " + crystalsCollected.Count);
			if(level ==1){GameStats.level1.hasAllCrystals = true;}
			if(level ==2){GameStats.level2.hasAllCrystals = true;}
		}
		if (fruitsCollected.Count == 1) {
			Debug.Log ("Capacity " + fruitsCollected.Count);
			if(level ==1){GameStats.level1.hasAllFruits = true;}
			if(level ==2){GameStats.level2.hasAllFruits = true;}
		}
	}

	public void SetStartPosition(Vector3 position){
		this.startingPosition = position;
	}

	public bool isRabbitAlive(){
		return !rabbitIsDead;
	}

	public void OnRabbitDeath(Rabbit rabbit){
		/*rabbit.GetComponent<Animator> ().SetBool("die", true);
		rabbit.GetComponent<Rigidbody2D>().isKinematic = true;
		rabbit.GetComponent<BoxCollider2D> ().enabled = false;*/
		rabbit.OnDeathProcess ();
		StartCoroutine (returnLater (rabbit));
		rabbitIsDead = true;
		if(rabbitLifes==1){
			onLoosePopup ();
			return;
		}
		rabbitLifes--;
		if (HealthUI.current != null) {
			HealthUI.current.HealthLost ();
		}
		//Debug.Log ("Death Is Here");

	}

	IEnumerator returnLater(Rabbit rabbit){
		yield return new WaitForSeconds (3);

		rabbitIsDead = false;

		rabbit.transform.position = this.startingPosition;
		rabbit.MakeNormalScale ();
		rabbit.GetComponent<Rigidbody2D>().isKinematic = false;
		rabbit.GetComponent<BoxCollider2D> ().enabled = true;
		rabbit.GetComponent<Animator> ().SetBool("die", false);
	}

	public void addCoins(int quantity){
		this.coins += quantity;
		coinsLabel.text = coins.ToString ("0000");

	}

	public void addFruits(Fruits.Type type){
		this.fruits ++;
		fruitsCollected.Add (type);
		fruitsLabel.text = fruits.ToString ();
	}

	public void addCrystals(Crystals.Type type){
		crystalsCollected.Add (type);
		Debug.Log ("Crystal collected count" + crystalsCollected.Count);
	}

	public void addHealth(){
		if(rabbitLifes<3){
			this.rabbitLifes++;
			HealthUI.current.HealthTaken ();
		}
	}

	private void SettingsWinWindow()
	{
		WinWindowSprites winSprites = winWindow.GetComponent<WinWindowSprites>();
		if (crystalsCollected.Contains(Crystals.Type.BLUE))
		{
			winSprites.BlueEmpty.sprite2D = winSprites.BlueCrystalSprite;
		}
		if (crystalsCollected.Contains(Crystals.Type.RED))
		{
			winSprites.RedEmpty.sprite2D = winSprites.RedCrystalSprite;
		}
		if (crystalsCollected.Contains(Crystals.Type.GREEN))
		{
			winSprites.GreenEmpty.sprite2D = winSprites.GreenCrystalSprite;
		}
		winSprites.coinsLabel.text = "+" + coins.ToString();
		winSprites.fruitsLabel.text = fruits.ToString();
	}

}
