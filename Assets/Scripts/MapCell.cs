using UnityEngine;
using System.Collections;

public class MapCell : MonoBehaviour
{
	public float gridHeight;
	public GameObject gridObject;
	public Sprite normal, hover, select;
	public int x, y;
	MeshRenderer gridMeshRenderer;
	bool hovered, selected;

	MapCellContent content;
	SpriteRenderer spriteRenderer;

	void Awake()
	{
		gridMeshRenderer = gridObject.GetComponent<MeshRenderer>();
		gridObject.transform.localPosition = new Vector3(0, gridHeight, 0);
		GetComponent<BoxCollider>().center = new Vector3(0, gridHeight - (GetComponent<BoxCollider>().size.y / 2), 0);
		spriteRenderer = gridObject.GetComponent<SpriteRenderer>();
	}

	public void UpdateContent()
	{
		if (Map.Data.GetCell(x, y).content >= 0)
		{
			if (content != null)
			{
				Destroy(content.gameObject);
			}
			content = Instantiate<MapCellContent>(FacilityPalette.GetObjectInCategory(0, Map.Data.GetCell(x, y).content));
			content.transform.SetParent(transform);
			content.transform.localPosition = Vector3.zero;
			SetGridHeight(content.groundHeight);
		}
		else if (Map.Data.GetCell(x, y).content < 0 && content != null)
		{
			Destroy(content.gameObject);
			SetGridHeight(0);
		}
	}

	void UpdateGridGraphic()
	{
		if (selected)
		{
			spriteRenderer.sprite = select;
		}
		else if (hovered)
		{
			spriteRenderer.sprite = hover;
		}
		else
		{
			spriteRenderer.sprite = normal;
		}
	}

	void SetGridColor(Color color)
	{
		gridMeshRenderer.material.SetColor("_Color", color);
	}

	void SetGridHeight(float h)
	{
		gridHeight = h;
		gridObject.transform.localPosition = new Vector3(0, gridHeight, 0);
		GetComponent<BoxCollider>().center = new Vector3(0, gridHeight - (GetComponent<BoxCollider>().size.y / 2), 0);
	}

	public bool Hovered
	{
		get { return hovered; }
		set
		{
			hovered = value;
			UpdateGridGraphic();
			if (value)
			{
				Map.SetHoveredCell(this);
			}
		}
	}
	public bool Selected
	{
		get { return selected; }
		set
		{
			selected = value;
			UpdateGridGraphic();
			if (value)
			{
				Map.AddSelectedCell(this);
			}
		}
	}
}