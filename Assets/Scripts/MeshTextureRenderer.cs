using UnityEngine;
using System.Collections;

public class MeshTextureRenderer : MonoBehaviour
{
	public Mesh mesh;
	public Material material;
	public Vector3 euler;
	public Vector3 offset;
	public Texture texture;
	public int width = 64, height = 64, depth = 0;

	Material tmpMaterial;
	RenderTexture rt;

	void Awake()
	{
		UpdateSettings();
	}

	void OnPostRender()
	{
		tmpMaterial.SetPass(0);
		Graphics.DrawMeshNow(mesh, transform.position + offset, Quaternion.Euler(euler));
	}

	public void SetSettings(Mesh me, Material ma)
	{
		mesh = me;
		material = ma;

		UpdateSettings();
	}
	public void SetSettings(Mesh me, Material ma, Vector3 os, Vector3 eu)
	{
		mesh = me;
		material = ma;
		offset = os;
		euler = eu;

		UpdateSettings();
	}

	void UpdateSettings()
	{
		rt = new RenderTexture(width, height, depth);
		GetComponent<Camera>().targetTexture = rt;

		tmpMaterial = new Material(material);
		tmpMaterial.SetTexture("_EmissionMap", material.mainTexture);
		Color color = material.color;
		tmpMaterial.SetColor("_EmissionColor", color);

		texture = rt;
	}
}