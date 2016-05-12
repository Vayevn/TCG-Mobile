using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UICardsFunctions : MonoBehaviour {




	public void Call_SetCardInfo(cardInfoHolder info){

		//Appelle la fonction SetCardInfo vers une instance unique
		SetCardInfo(GameObject.Find("CardPrevisualization"), info);

	}


	public void SetCardInfo(GameObject card, cardInfoHolder info){

		//Settup les infos de la carte finale
		card.transform.Find("CardName").GetComponent<Text>().text = info.cardName;
		card.transform.Find("CardPic").GetComponent<Image>().sprite = info.cardPic;
		card.transform.Find("CardEffect").GetComponent<Text>().text = EffectToString(info);
		card.transform.Find("CardCost").GetComponent<Text>().text = info.timeLoad.ToString();

	}

	public string EffectToString(cardInfoHolder info){

		string effet = info.typeOfCard.ToString();
		string cible = info.targetAlliance.ToString();

		string connection = (info.targetAlliance == carte.targetType.Neutral) ? " a " : " an ";

		return effet + connection + cible + " unit.";
	}

	public void IncrementCardNB(){
		
	}

	public void DecrementCardNB(){
		
	}


}
