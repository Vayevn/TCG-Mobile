using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;

[CustomEditor(typeof(CustomList))]
public class CustomListEditor : Editor {

	enum displayFieldType {DisplayAsCard, DisplayAsDeck}
	displayFieldType DisplayFieldType;

	CustomList t;
	SerializedObject GetTarget;
	SerializedProperty ThisList;
	int ListSize;

	void OnEnable(){
		t = (CustomList)target;
		GetTarget = new SerializedObject(t);
		ThisList = GetTarget.FindProperty("ExistingElementsList"); //Reference
	}

	public override void OnInspectorGUI(){

		GetTarget.Update();

		CreateSpaceInEditorWindow(4);

		//Resize
		EditorGUILayout.LabelField("Set the number of existing cards");
		ListSize = ThisList.arraySize;
		ListSize = EditorGUILayout.IntField ("List SizeCards nb", ListSize);

		if(ListSize != ThisList.arraySize){
			while(ListSize > ThisList.arraySize){
				ThisList.InsertArrayElementAtIndex(ThisList.arraySize);
			}
			while(ListSize < ThisList.arraySize){
				ThisList.DeleteArrayElementAtIndex(ThisList.arraySize - 1);
			}
		}


		CreateSpaceInEditorWindow(4);

		//Create cards
		EditorGUILayout.LabelField("Create cards");

		if(GUILayout.Button("Add New card",  GUILayout.Height(100))){
			t.ExistingElementsList.Add(new carte());
		}

		CreateSpaceInEditorWindow(2);

		//Affiche les cartes
		for(int i = 0; i < ThisList.arraySize; i++){
			SerializedProperty MyListRef = ThisList.GetArrayElementAtIndex(i);

			SerializedProperty Name = MyListRef.FindPropertyRelative("cardName");
			SerializedProperty Picture = MyListRef.FindPropertyRelative("cardPic");
			SerializedProperty Effect = MyListRef.FindPropertyRelative("typeOfCard");
			SerializedProperty Target = MyListRef.FindPropertyRelative("targetAlliance");
			SerializedProperty CoolDown = MyListRef.FindPropertyRelative("timeLoad");

			EditorGUILayout.PropertyField(Name);
			EditorGUILayout.PropertyField(Picture);
			EditorGUILayout.PropertyField(Effect);
			EditorGUILayout.PropertyField(Target);
			EditorGUILayout.PropertyField(CoolDown);

			CreateSpaceInEditorWindow(3);

			//Remove
			if(GUILayout.Button("Remove (" + t.ExistingElementsList[i].cardName + ") ?", GUILayout.Width(300), GUILayout.Height(25))){
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
