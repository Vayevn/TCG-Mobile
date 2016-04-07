using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class cartesExistantes : MonoBehaviour {
	
	//Ces deux variables faut les rendres statiques, puis editables depuis l'editor avec un custom editor
	public rapportCoutY[] _rapportCoutY = new rapportCoutY[4];
	public List<carte> listeCartesExistantes = new List<carte>();

	string filePath;
	BinaryFormatter formatter = new BinaryFormatter();
	static public cardListData persistantData = new cardListData();

	public void SaveCurrentCardsList(){

		persistantData.listeCartesExistantesData = listeCartesExistantes;

		filePath = Path.Combine(Application.persistentDataPath, "existingCardList.dat");

		FileStream stream = File.OpenWrite(filePath);
		
		formatter.Serialize(stream, persistantData);
		

		Debug.Log("Card List Saved !");

	}

	public void LoadCardsList(){

		try
		{
			using (FileStream stream = File.OpenRead(filePath))
			{
				//listeCartesExistantes = liste sauvegardee
				persistantData = formatter.Deserialize(stream) as cardListData;
				Debug.Log("La liste de cartes a bien été chargée");
			}
		}
		catch (FileNotFoundException)
		{
			Debug.Log("No persistant data to load");
		}
//		catch (InvalidCastException)
//		{
//			Debug.LogWarning("Persistant data class has changed");
//		}
	}

}

[System.Serializable]
public class rapportCoutY
{
	public int[] rapportX = new int[3];
}

