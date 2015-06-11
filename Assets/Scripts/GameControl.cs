using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class GameControl : MonoBehaviour
{
	static GameControl instance;
	[SerializeField]
	GameData gameData;

	void Awake()
	{
		if (instance == null)
		{
			instance = this;
			DontDestroyOnLoad(this.gameObject);
		}
		else if (instance != this)
		{
			Destroy(this.gameObject);
		}
	}

	public static void NewAgency(string name)
	{
		AgencyData agencyData = new AgencyData(name);
		Instance.gameData.agencyData = agencyData;
	}
	public static void NewAgency(string name, float money)
	{
		AgencyData agencyData = new AgencyData(name, money);
		Instance.gameData.agencyData = agencyData;
	}

	public static void Save()
	{
		BinaryFormatter bf = new BinaryFormatter();
		FileStream file = File.Create(Application.persistentDataPath + "/savedGame.iatsf");
		bf.Serialize(file, Instance.gameData);
		file.Close();
	}

	public static void Load()
	{
		if (File.Exists(Application.persistentDataPath + "/savedGame.iatsf"))
		{
			BinaryFormatter bf = new BinaryFormatter();
			FileStream file = File.Open(Application.persistentDataPath + "/savedGame.iatsf", FileMode.Open);
			Instance.gameData = bf.Deserialize(file) as GameData;
			file.Close();
			if (Application.loadedLevelName == "FacilityScene")
			{
				Application.LoadLevel("FacilityScene");
			}
		}
	}


	public static GameControl Instance { get { return instance; } }
	public static GameData GameData { get { return Instance.gameData; } set { Instance.gameData = value; } }
	public static AgencyData AgencyData { get { return GameData.agencyData; } set { GameData.agencyData = value; } }
}