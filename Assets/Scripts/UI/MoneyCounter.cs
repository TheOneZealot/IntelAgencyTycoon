using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MoneyCounter : MonoBehaviour
{
	void Awake()
	{
		GetComponentInChildren<Text>().text = GameControl.AgencyData.money.ToString();
	}
}