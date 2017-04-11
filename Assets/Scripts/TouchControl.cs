using UnityEngine;
using System.Collections;

public class TouchControl : MonoBehaviour
{
	public RailDrawManager RailManager;
	public LineRailScript lineRailUI;
	bool selected = false;
	LayerMask maskPointRail;
	RaycastHit2D hit2d;
	Vector3 pointTouch;
	Vector3 pointStartRail;
	public Rigidbody2D rgCurrent;
	void Start ()
	{
		maskPointRail = LayerMask.NameToLayer ("POINT_RAIL");
	}
	Vector3 pointEndRail;
	void Update ()
	{
		if (!selected) {
			CheckPointBuild ();
		} else {
			if (Input.GetMouseButton (0)) {
				pointTouch = Camera.main.ScreenToWorldPoint (Input.mousePosition);
				pointTouch = new Vector3 (pointTouch.x, pointTouch.y, 0);
				pointEndRail = pointTouch;
				lineRailUI.SetInfo (pointStartRail, pointEndRail);
			} else {
				selected = false;
				RailManager.DrawRailPhysics ();
			}
		}
	}

	void CheckPointBuild ()
	{
		if (Input.GetMouseButton (0)) {
			pointTouch = Camera.main.ScreenToWorldPoint (Input.mousePosition);
			hit2d = Physics2D.Raycast (pointTouch, Vector2.zero, 1, 1 << maskPointRail);
			if (hit2d != null && hit2d.collider != null) {
				if (hit2d.collider.tag == "PointRailMain") {
					this.pointStartRail = hit2d.transform.position;
					this.rgCurrent = hit2d.transform.GetComponent<Rigidbody2D> ();
					lineRailUI.setPivot (pointStartRail);
					this.selected = true;
				}
				if (hit2d.collider.tag == "PointRailTemp") {
					this.pointStartRail = hit2d.transform.position;
					this.rgCurrent = hit2d.transform.GetComponent<Rigidbody2D> ();
					lineRailUI.setPivot (pointStartRail);
					this.selected = true;
				}
			}
		}
	}
}
