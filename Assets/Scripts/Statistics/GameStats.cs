using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStats : MonoBehaviour {
	public static LevelStatistics level1 = new LevelStatistics();
	public static LevelStatistics level2 = new LevelStatistics();

	static int totalCoin = 0;
	static bool secondLevelOpened = false;

	// Use this for initialization


	public static int getTotalCoins(){
		return totalCoin;
	}
		
	// Update is called once per frame
/*	public static void openSecondLevel () {
		secondLevelOpened = true;
	}

	public static bool isSecondLevelOpened(){
		return secondLevelOpened;
	}*/

	public static int TotalCoins
	{
		get { return PlayerPrefs.GetInt("total_coins", 0); }
	}

	public static void AddCoins(int amount)
	{
		int totalCoins = TotalCoins + amount;
		PlayerPrefs.SetInt("total_coins", totalCoins);
	}

	public static LevelStatistics GetLevelStatistics(string LevelName)
	{
		string str =  PlayerPrefs.GetString("level_stat_" + LevelName, null);
		LevelStatistics result =JsonUtility.FromJson<LevelStatistics>(str);
		return result;
	}

	public static void SetLevelData(string LevelName, LevelStatistics stat)
	{
		string str = JsonUtility.ToJson(stat);
		PlayerPrefs.SetString("level_stat_" + LevelName, str);
	}

	public static bool IsSecondLevelOpened()
	{
		return PlayerPrefs.GetInt("second_level_open", 0) == 1;
	}

	public static void SetSecondLevelOpen(bool state)
	{
		PlayerPrefs.SetInt("second_level_open", state ? 1 : 0);
	}

}
