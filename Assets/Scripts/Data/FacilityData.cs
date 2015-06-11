using UnityEngine;
using System.Collections;

[System.Serializable]
public class MapData
{
	public string name;
	public CellData[,] cells;

	public MapData(string name)
	{
		this.name = name;

		Initialize();
	}

	public void Initialize()
	{
		cells = new CellData[Map.width, Map.height];
		for (int x = 0; x < Map.width; x++)
		{
			for (int y = 0; y < Map.height; y++)
			{
				cells[x, y] = new CellData();
			}
		}
	}

	public CellData GetCell(int x, int y)
	{
		return cells[x, y];
	}
}

[System.Serializable]
public class CellData
{
	public int content = -1;
}