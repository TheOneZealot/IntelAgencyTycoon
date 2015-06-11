using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using System.Collections;

public class FacilityPaletteInterface : MonoBehaviour
{
	public FacilityPaletteButton buttonPrefab;
	public int category;

	void Start()
	{
		for (int i = 0; i < FacilityPalette.Instance.categories[category].objects.Length; i++)
		{
			FacilityPaletteButton btn = Instantiate<FacilityPaletteButton>(buttonPrefab);
			btn.transform.SetParent(transform, false);
			(btn.transform as RectTransform).anchoredPosition = new Vector2(10 + (90 * i), 0);
			btn.GetComponentInChildren<RawImage>().texture = FacilityPalette.Instance.categories[category].icons[i];
			btn.index = i;
			btn.category = category;
			btn.Initialize();
		}
	}
}