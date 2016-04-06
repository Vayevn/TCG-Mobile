using UnityEngine;
using System.Collections;

public class carte
{

	public string cardName = "unnamed card";
	public effectType typeOfCard;	//type d'effet de la carte
	public targetType targetAlliance;	//cible de la carte
	private float timeLoad = 0;

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

	//Constructor
	public carte (string name, effectType initialType, targetType initialTargetAlliance){
	
		cardName = name;
		typeOfCard = initialType;
		targetAlliance = initialTargetAlliance;

		cartesExistantes cardScript = GameObject.Find ("Manager").GetComponent<cartesExistantes> ();
		timeLoad = cardScript._rapportCoutY[(int)initialType].rapportX[(int)initialTargetAlliance];

	}

}

//class MyClass
//{
//	public string name;
//	public MyClass(string aName)
//	{
//		name = aName;
//	}
//}
//
////MyClass mc = new MyClass("FooBar");
