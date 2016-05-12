using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;

[CustomEditor(typeof(decksManager))]
public class DeckManagerCustomEditor : Editor {

	decksManager t;
	SerializedObject GetTarget;
	SerializedProperty ThisList;
	int ListSize;


	void OnEnable(){
		t = (decksManager)target;
		GetTarget = new SerializedObject(t);
		ThisList = GetTarget.FindProperty("existingDecks"); // Find the List in our script and create a refrence of it
	}

	public string[] options = new string[] {"TypecardA", "TypecardB", "Etc"}; //Ceci devait servir à définir quelle carte est créée au "Add"

	public override void OnInspectorGUI(){

		GetTarget.Update();

		CreateSpaceInEditorWindow(2);

		//Créer un deck
		EditorGUILayout.LabelField("Create a deck");

		if(GUILayout.Button("Add New deck",  GUILayout.Height(100))){
			t.existingDecks.Add(new deck());
		}

		CreateSpaceInEditorWindow(4);

		//Pop up pour choisir quelle carte générer au "Add"
		int index = 0;
		index = EditorGUILayout.Popup(index, options, EditorStyles.popup);

		//Afficher tous les decks
		for(int i = 0; i < ThisList.arraySize; i++){
			SerializedProperty MyListRef = ThisList.GetArrayElementAtIndex(i);

			SerializedProperty Name = MyListRef.FindPropertyRelative("deckName");
			SerializedProperty Cards = MyListRef.FindPropertyRelative("cardsInTheDeck");
	
			EditorGUILayout.PropertyField(Name);

			if(GUILayout.Button("Add New Card", GUILayout.MaxWidth(130), GUILayout.MaxHeight(20))){
				
				Cards.InsertArrayElementAtIndex(Cards.arraySize);

			}

			//Afficher toutes les cartes dans les decks
			for (int j = 0; j < Cards.arraySize; j++) {
				EditorGUILayout.BeginHorizontal();
				EditorGUILayout.LabelField("Cardname " + Cards.FindPropertyRelative("cardName"), GUILayout.MaxWidth(120));	//ICI je n'ai pas compris comment deserialiser
//				Cards.GetArrayElementAtIndex(j).intValue = EditorGUILayout.IntField("", Cards.GetArrayElementAtIndex(j).intValue, GUILayout.MaxWidth(100));
				if(GUILayout.Button("-", GUILayout.MaxWidth(15), GUILayout.MaxHeight(15))){
					Cards.DeleteArrayElementAtIndex(j);
				}
//				EditorGUILayout.PropertyField(Cards.GetArrayElementAtIndex(j));
//				if(GUILayout.Button("Remove " + j.ToString(), GUILayout.MaxWidth(100), GUILayout.MaxHeight(15))){
//					Cards.DeleteArrayElementAtIndex(j);
//				}
				EditorGUILayout.EndHorizontal();
			}

			//Remove
			if(GUILayout.Button("Delete (" + t.existingDecks[i].deckName + ") deck ?", GUILayout.Width(300), GUILayout.Height(25))){
				ThisList.DeleteArrayElementAtIndex(i);
			}

			CreateSpaceInEditorWindow(4);
		}


		GetTarget.ApplyModifiedProperties();

	}

	public void CreateSpaceInEditorWindow(int value){

		for (int i = 0; i < value; i++) {
			EditorGUILayout.Space();
		}

	}

}
