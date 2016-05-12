using UnityEngine;
using System.Collections;
using System.Collections.Generic;

//Ce script est la version non-fonctionnelle du manager de deck.
//Ceci est du à un défaut de comprehention des SerializableProperty d'unity

public class decksManager : MonoBehaviour {


//	static List<carte> currentDeckList;	//liste du deck actuellement choisi pour jouer

	public List<deck> existingDecks;

	void AddDeck(){
		//Add a new index position to the end of our list
		existingDecks.Add(new deck());
	}

	void RemoveDeck(int index){
		//Remove an index position from our list at a point in our list array
		existingDecks.RemoveAt(index);
	}


}
