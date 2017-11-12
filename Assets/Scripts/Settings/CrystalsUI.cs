using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrystalsUI : MonoBehaviour {

	public static CrystalsUI current;

	public UI2DSprite GreenEmpty;
	public UI2DSprite BlueEmpty;
	public UI2DSprite RedEmpty;

	public Sprite GreenCrystalSprite;
	public Sprite BlueCrystalSprite;
	public Sprite RedCrystalSprite;

		
	public void putOnPanel(Crystals crystal)
	{
		switch (crystal.type)
		{
		case Crystals.Type.GREEN:
			GreenEmpty.sprite2D = GreenCrystalSprite;
			return;
		case Crystals.Type.BLUE:
			BlueEmpty.sprite2D = BlueCrystalSprite;
			return;
		case Crystals.Type.RED:
			RedEmpty.sprite2D = RedCrystalSprite;
			return;
		}

	}
		
	void Awake () {
		current = this;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
