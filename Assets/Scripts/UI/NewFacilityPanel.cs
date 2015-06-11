using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class NewFacilityPanel : MonoBehaviour
{
	public Text facilityName;

	void Start()
	{
		if (Map.Data != null)
		{
			Destroy(this.gameObject);
		}
	}

	public void NewFacilityAccept()
	{
		Destroy(this.gameObject);
		facilityName.text = Map.Data.name;
		Map.Instance.Initialize();
	}

	public void NewFacilityCancel()
	{

	}
}
