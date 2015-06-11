using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public class AgencyData
{
	public string name;
	public float money;
	public List<MapData> facilities;

	public AgencyData(string name)
	{
		this.name = name;
		this.facilities = new List<MapData>();
	}
	public AgencyData(string name, float money)
	{
		this.name = name;
		this.money = money;
		this.facilities = new List<MapData>();
	}

	public void NewFacility(string name)
	{
		MapData facility = new MapData(name);
		facility.Initialize();
		facilities.Add(facility);
	}
}