using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;

public class Player : MonoBehaviour
{
	public LayerMask interactLayer;
	public float speed = 10.0f;

	new Camera camera;

	void Awake()
	{
		camera = GetComponentInChildren<Camera>();
	}

	void Update()
	{
		float inpHoriz = Input.GetAxis("Horizontal");
		float inpVert = Input.GetAxis("Vertical");

		transform.Translate(new Vector3(inpHoriz, 0, inpVert) * speed * Time.deltaTime);

		RaycastHit mouseHit;
		Ray mouseRay = camera.ScreenPointToRay(Input.mousePosition);
		if (Physics.Raycast(mouseRay, out mouseHit, Mathf.Infinity, interactLayer.value))
		{
			MapCell cell = mouseHit.collider.gameObject.GetComponent<MapCell>();
			if (cell != null)
			{
				cell.Hovered = true;
			}
		}

		if (Input.GetButton("Primary") && !EventSystem.current.IsPointerOverGameObject())
		{
			Primary();
		}
		else if (Input.GetButton("Secondary") && !EventSystem.current.IsPointerOverGameObject())
		{
			Secondary();
		}
		else if (Input.GetButtonUp("Primary"))
		{
			EndPrimary();
		}
		else if (Input.GetButtonUp("Secondary"))
		{
			EndSecondary();
		}
	}

	public virtual void Primary() { }
	public virtual void Secondary() { }
	public virtual void EndPrimary() { }
	public virtual void EndSecondary() { }

	public void ResetView()
	{
		transform.position = Vector3.zero;
	}
}
