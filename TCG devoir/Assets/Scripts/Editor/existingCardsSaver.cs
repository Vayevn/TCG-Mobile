using UnityEngine;
using System.Collections;
using UnityEditor;

[CustomEditor(typeof(cartesExistantes))]
public class existingCardsSaver : Editor
{
	public override void OnInspectorGUI()
	{
		DrawDefaultInspector();
		
		cartesExistantes myScript = (cartesExistantes)target;
		if(GUILayout.Button("Save Card List"))
		{
			myScript.SaveCurrentCardsList();
		}
	}
}

//Initialisation d'unity
[InitializeOnLoad]
public class Startup {
	static Startup()
	{
		Debug.Log("Bonjour et bienvenue dans ce projet Unity");

		//Appelle la fonction qui met à jour la liste de cartes dans cartesExistantes
		//ICI

	}
}