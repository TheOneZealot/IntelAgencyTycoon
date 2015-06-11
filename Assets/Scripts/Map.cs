using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Map : MonoBehaviour
{
	public const int width = 25, height = 25;
	public Vector3 cellSize = new Vector3(1, 1, 1);
	public MapCell cellPrefab;
	public static int facilityIndex = 0;

	static Map instance;
	MapCell[,] cells;
	MapCell hoveredCell;
	List<MapCell> selectedCells = new List<MapCell>();

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
		Initialize();
	}

	public void Initialize()
	{
		Vector3 cellOffset = new Vector3(width * cellSize.x, 0, height * cellSize.z) / -2 + new Vector3(cellSize.x / 2, 0, cellSize.z / 2);
		cells = new MapCell[width, height];
		for (int x = 0; x < width; x++)
		{
			for (int y = 0; y < height; y++)
			{
				MapCell newCell = Instantiate<MapCell>(cellPrefab);
				newCell.transform.parent = transform.GetChild(0);
				newCell.transform.localPosition = new Vector3(x * cellSize.x, 0, y * cellSize.z) + cellOffset;
				newCell.x = x;
				newCell.y = y;
				newCell.UpdateContent();
				cells[x, y] = newCell;
			}
		}
	}

	public void UpdateCellsContent()
	{
		for (int x = 0; x < width; x++)
		{
			for (int y = 0; y < height; y++)
			{
				cells[x, y].UpdateContent();
			}
		}
	}

	public static void SetHoveredCell(MapCell cell)
	{
		if (Instance.hoveredCell != cell)
		{
			if (Instance.hoveredCell != null)
			{
				Instance.hoveredCell.Hovered = false;
			}
			Instance.hoveredCell = cell;
		}
	}

	public static void AddSelectedCell(MapCell cell)
	{
		Instance.selectedCells.Add(cell);
	}

	public static void ResetSelectedCells()
	{
		foreach (MapCell cell in Instance.selectedCells)
		{
			cell.Selected = false;
		}
		Instance.selectedCells.RemoveAll(x => x != null);
	}

	public static Map Instance { get { return instance; } }
	public static MapData Data { get { return GameControl.AgencyData.facilities[facilityIndex]; } }
}