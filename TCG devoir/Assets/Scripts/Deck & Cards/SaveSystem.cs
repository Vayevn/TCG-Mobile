using UnityEngine;
using System.Collections;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using UnityEngine.UI;

//SaveTest

public class SaveSystem : MonoBehaviour {

	public string name;
	public float timePlayed = 0;
	public Text timeText;

	void Start()
	{
		Load();
	}

	void Update()
	{
		timePlayed += Time.deltaTime;
		timeText.text = timePlayed.ToString();
	}

	public void Save()
	{
		BinaryFormatter bf = new BinaryFormatter();
		FileStream file = File.Create(Application.persistentDataPath + "/playerInfo.dat");

		saveData data = new saveData();
		data.name = name;
		data.tempsDeJeu = timePlayed;

		bf.Serialize(file, data);
		file.Close();

		Debug.Log("Saved " + name + " ! at : " + timePlayed);

	}

	public void Load()
	{
		if(File.Exists(Application.persistentDataPath + "/playerInfo.dat"))
		{
			BinaryFormatter bf = new BinaryFormatter();
			FileStream file = File.Open(Application.persistentDataPath + "/playerInfo.dat", FileMode.Open);
			saveData data = (saveData)bf.Deserialize(file);
			file.Close();

			name = data.name;
			timePlayed = data.tempsDeJeu;

			Debug.Log("Loaded " + name + " ! at : " + timePlayed);
		}
	}

}
