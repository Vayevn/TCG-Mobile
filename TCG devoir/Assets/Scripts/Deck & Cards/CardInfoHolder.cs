using UnityEngine;
using System;
using System.Collections;

public class cardInfoHolder : MonoBehaviour
{
	//Ce script sert à stocker les infos d'une carte dans un gameobject
	public string cardName = "unnamed card";
	public Sprite cardPic;
	public carte.effectType typeOfCard;	//type d'effet de la carte
	public carte.targetType targetAlliance;	//cible de la carte
	public float timeLoad = 0;

}