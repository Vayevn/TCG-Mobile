using UnityEngine;
using System;
using System.Collections.Generic;

//A attacher sur le prefab contenant toutes les cartes ou decks du jeu
public class CustomList : MonoBehaviour {


	public List<carte> ExistingElementsList = new List<carte>(1);

	void Add(){
		//Add a new index position to the end of our list
		ExistingElementsList.Add(new carte());
	}

	void Remove(int index){
		//Remove an index position from our list at a point in our list array
		ExistingElementsList.RemoveAt(index);
	}


}
