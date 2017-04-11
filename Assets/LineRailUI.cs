using UnityEngine;
using System.Collections;

public class LineRailUI : MonoBehaviour
{
	public LineRenderer lineRail;
	public RailDrawManager RailManager;
	void Start ()
	{
		lineRail.sortingLayerName = "BG";
		lineRail.sortingOrder = 10;
	}

	public void drawLine (Vector3 pivot, Vector3 pointEnd)
	{
		int index = 0;
		this.transform.position = pivot;
		Vector3 direction = pointEnd - pivot;
		direction.Normalize ();
		this.transform.rotation = Quaternion.AngleAxis (
			Mathf.Atan2 (direction.y, direction.x) * 180 / Mathf.PI,
			new Vector3 (0, 0, 1));
		float distance = Vector3.Distance (pivot, pointEnd);
		Vector3 posEnd;
		posEnd = new Vector3 (0, distance, 0);
		lineRail.SetPosition (1, posEnd);

		index = Mathf.RoundToInt (distance-0.25f);

		RailManager.SetInfoDrawRail (index,pivot, this.transform.rotation,pointEnd);
	}

}
