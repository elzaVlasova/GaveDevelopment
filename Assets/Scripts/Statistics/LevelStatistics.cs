using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]

public class LevelStatistics : MonoBehaviour {

	public bool hasAllCrystals = false;
	public bool hasAllFruits = false;
	public bool levelPassed = false;
	public List<int> collectedFruits = new List<int>();

}

