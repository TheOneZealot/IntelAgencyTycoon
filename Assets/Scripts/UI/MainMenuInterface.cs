using UnityEngine;
using System.Collections;

public class MainMenuInterface : MonoBehaviour
{
	public void NewGame()
	{
		GameControl.GameData = new GameData();
		Application.LoadLevel("NewGame");
	}

	public void Continue()
	{
		GameControl.Load();
		Application.LoadLevel("FacilityScene");
	}

	public void Quit()
	{
		Application.Quit();
	}
}
