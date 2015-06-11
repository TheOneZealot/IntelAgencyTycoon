using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerInterface : MonoBehaviour
{
	void Awake()
	{
		GetComponentInChildren<Text>().text = GameControl.GameData.agencyData.name;
	}
}