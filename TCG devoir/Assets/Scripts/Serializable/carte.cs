using UnityEngine;
using System;
using System.Collections;

[Serializable]
public class carte
{
		
	public string cardName = "unnamed card";
	public Sprite cardPic;
	public effectType typeOfCard;	//type d'effet de la carte
	public targetType targetAlliance;	//cible de la carte
	public float timeLoad = 0;

	public enum effectType
	{
		Move,
		Pop,
		Kill,
		Convert
	}

	public enum targetType
	{
		Neutral,
		Ally,
		Ennemy
	}

}