using UnityEngine;
using System.Collections;

public class FacilityEditMode
{
	protected int interactMask = 8;
	protected int contentMask = 9;

	public virtual void Primary() { }
	public virtual void Secondary() { }
	public virtual void EndPrimary() { }
	public virtual void EndSecondary() { }

	public bool MouseRaycast(out RaycastHit hit, int mask)
	{
		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		return Physics.Raycast(ray, out hit, Mathf.Infinity, mask);
	}
}

public class SingleEditMode : FacilityEditMode
{
	public override void Primary()
	{
		RaycastHit hit;
		if (MouseRaycast(out hit, 1 << interactMask))
		{
			MapCell cell = hit.collider.gameObject.GetComponent<MapCell>();
			if (cell != null)
			{
				cell.Selected = true;
				Map.Data.GetCell(cell.x, cell.y).content = FacilityPalette.Instance.categories[0].selected;
				cell.UpdateContent();
			}
		}
	}

	public override void Secondary()
	{
		RaycastHit hit;
		if (MouseRaycast(out hit, 1 << interactMask))
		{
			MapCell cell = hit.collider.gameObject.GetComponent<MapCell>();
			if (cell != null)
			{
				cell.Selected = true;
				Map.Data.GetCell(cell.x, cell.y).content = -1;
				cell.UpdateContent();
			}
		}
	}

	public override void EndPrimary()
	{
		Map.ResetSelectedCells();
	}

	public override void EndSecondary()
	{
		Map.ResetSelectedCells();
	}
}