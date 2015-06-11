using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class NewGameInterface : MonoBehaviour
{
	public GameObject agencyPanel, facilityPanel;

	public void CreateAgency()
	{
		string name = agencyPanel.GetComponentInChildren<InputField>().text;
		GameControl.NewAgency(name, 10000.0f);
		Destroy(agencyPanel);
		facilityPanel.SetActive(true);
	}

	public void CreateFacility()
	{
		string name = facilityPanel.GetComponentInChildren<InputField>().text;
		GameControl.AgencyData.NewFacility(name);
		Map.facilityIndex = 0;
		Application.LoadLevel("FacilityScene");
	}
}