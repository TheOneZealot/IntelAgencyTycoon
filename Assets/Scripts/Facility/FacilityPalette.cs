using UnityEngine;
using System.Collections;

public class FacilityPalette : MonoBehaviour
{

	public PaletteCategory[] categories;
	public int selected = 0;

	public MeshTextureRenderer textureRenderer;

	static FacilityPalette instance;

	void Awake()
	{
		if (instance == null)
		{
			instance = this;
		}
		else if (instance != this)
		{
			Destroy(this.gameObject);
		}
		for (int i = 0; i < categories.Length; i++)
		{
			categories[i].CreateIcons();
		}
	}

	public static FacilityPalette Instance { get { return instance; } }
	public static MapCellContent GetObjectInCategory(int c, int o)
	{
		return Instance.categories[c].objects[o];
	}

	public static MapCellContent SelectedObject { get { return Instance.categories[Instance.selected].SelectedObject; } }
}

[System.Serializable]
public class PaletteCategory
{
	public string name;
	public MapCellContent[] objects;
	public Texture[] icons;
	public int selected = 0;

	public void CreateIcons()
	{
		icons = new Texture[objects.Length];
		for (int i = 0; i < icons.Length; i++)
		{
			Mesh mesh = objects[i].GetComponent<MeshFilter>().sharedMesh;
			Material material = objects[i].GetComponent<MeshRenderer>().sharedMaterial;
			Vector3 offset = new Vector3(0, 0, 2);
			Vector3 euler = new Vector3(0, 0, 0);
			MeshTextureRenderer newTexRend = GameObject.Instantiate<MeshTextureRenderer>(FacilityPalette.Instance.textureRenderer);
			newTexRend.SetSettings(mesh, material, offset, euler);
			icons[i] = newTexRend.texture;
		}
	}

	public MapCellContent SelectedObject { get { return objects[selected]; } }
}