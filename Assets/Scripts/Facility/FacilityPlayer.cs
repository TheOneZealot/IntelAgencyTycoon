using UnityEngine;
using System.Collections;

public class FacilityPlayer : Player
{
	public int currentEditMode = 0;
	FacilityEditMode[] editModes;

	void Start()
	{
		editModes = new FacilityEditMode[] 
		{ 
			new SingleEditMode()
		};
	}

	public override void Primary()
	{
		editModes[currentEditMode].Primary();
	}
	public override void Secondary()
	{
		editModes[currentEditMode].Secondary();
	}
	public override void EndPrimary()
	{
		editModes[currentEditMode].EndPrimary();
	}
	public override void EndSecondary()
	{
		editModes[currentEditMode].EndSecondary();
	}
}