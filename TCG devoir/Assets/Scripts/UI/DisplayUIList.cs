using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class DisplayUIList : MonoBehaviour {
	
	public CustomList listScript;
	public GameObject UIToDisplay;

	void Start(){

		RectTransform containerRectTransform = GetComponent<RectTransform>();
		float CardUIHeight = UIToDisplay.GetComponent<LayoutElement>().preferredHeight;
		VerticalLayoutGroup vertGroup = GetComponent<VerticalLayoutGroup>();

		//Sert a calculer l'espace occupé par toutes les cartes
		float curHeight = 0;

		for (int i = 0; i < listScript.ExistingElementsList.Count; i++) {

			//Crée une carte et lui set son canvas
			GameObject lastInstance = (GameObject) Instantiate(UIToDisplay, containerRectTransform.position, Quaternion.identity);
			lastInstance.GetComponent<RectTransform>().SetParent(containerRectTransform, false);

			//Calcul de l'espace occupé
			curHeight += CardUIHeight + vertGroup.spacing;
			//Si cet espace dépasse du container, alors aggrandir le container
			if(containerRectTransform.rect.height < curHeight){
				containerRectTransform.sizeDelta = new Vector2(containerRectTransform.rect.width, curHeight);
			}

			//Settup de la case carte
				
			lastInstance.transform.Find("CardName/TextName").GetComponent<Text>().text = listScript.ExistingElementsList[i].cardName;
			cardInfoHolder infoHolderScript = lastInstance.transform.Find("InfoContainer").GetComponent<cardInfoHolder>();
			infoHolderScript.cardName = listScript.ExistingElementsList[i].cardName;

			infoHolderScript.cardPic = listScript.ExistingElementsList[i].cardPic;
			infoHolderScript.typeOfCard = listScript.ExistingElementsList[i].typeOfCard;
			infoHolderScript.targetAlliance = listScript.ExistingElementsList[i].targetAlliance;
			infoHolderScript.timeLoad = listScript.ExistingElementsList[i].timeLoad;

		}

	}
		
}
