using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class FacilityInterface : MonoBehaviour
{
	public Button paletteButtonPrefab;
	public GameObject tabPrefab;

	public GameObject[] paletteTabs;
	public Text facilityNameText;
	public GameObject pauseMenu;

	void Start()
	{
		PaletteChangeTab(0);
		facilityNameText.text = Map.Data.name;
	}

	void Update()
	{
		if (Input.GetButtonDown("Pause"))
		{
			pauseMenu.SetActive(!pauseMenu.activeSelf);
		}
	}

	public void PaletteChangeTab(int id)
	{
		if (paletteTabs.Length > 0 && paletteTabs[id] != null)
		{
			for (int i = 0; i < paletteTabs.Length; i++)
			{
				if (i == id)
				{
					paletteTabs[id].gameObject.SetActive(true);
				}
				else
				{
					paletteTabs[i].gameObject.SetActive(false);
				}
			}
		}
	}
}