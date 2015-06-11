using UnityEngine;
using System.Collections;

public class PauseMenu : MonoBehaviour
{
	public void Save()
	{
		GameControl.Save();
	}

	public void Load()
	{
		GameControl.Load();
	}
	
	public void Quit()
	{
		Application.LoadLevel("MainMenu");
	}
}
