using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class FacilityPaletteButton : MonoBehaviour
{
	public int category, index;

	public void Initialize()
	{
		Button.ButtonClickedEvent clickEvent = new Button.ButtonClickedEvent();
		clickEvent.AddListener(Select);
		GetComponent<Button>().onClick = clickEvent;
		GetComponentInChildren<Text>().text = FacilityPalette.GetObjectInCategory(category, index).price.ToString();
	}

	void Select()
	{
		FacilityPalette.Instance.categories[category].selected = index;
	}
}
