using UnityEngine;
using System.Collections;

public class CheckPointEnd : MonoBehaviour
{
	LayerMask maskPointRail;
	RaycastHit2D hit2d;
	Vector3 temp;
	GameObject tileTemp;
	bool dupPoint = false;
	Rigidbody2D rigiB;

	void Awake ()
	{
		this.maskPointRail = LayerMask.NameToLayer ("POINT_RAIL");
	}

	public Vector3 PointEndFix ()
	{
		hit2d = Physics2D.Raycast (this.transform.position, Vector2.zero, 10, 1 << maskPointRail);
		if (hit2d != null && hit2d.collider != null) {
			if (hit2d.collider.tag == "PointRail") {
				this.temp = hit2d.transform.position;
				this.tileTemp = hit2d.collider.gameObject;
				this.dupPoint = false;
				//	print (pointEndRail);
			}
			if (hit2d.collider.tag == "PointRailMain") {
				this.temp = hit2d.transform.position;
				this.tileTemp = hit2d.collider.gameObject;
				this.dupPoint = true;
				this.rigiB = hit2d.transform.GetComponent<Rigidbody2D> ();
				//	print (pointEndRail);
			}
			if (hit2d.collider.tag == "PointRailTemp") {
				this.temp = hit2d.transform.position;
				this.tileTemp = hit2d.collider.gameObject;
				this.dupPoint = true;
				this.rigiB = hit2d.transform.GetComponent<Rigidbody2D> ();
				//	print (pointEndRail);
			}
		}


		RailDrawManager.Manager.TilePointCur = this.tileTemp;
		RailDrawManager.Manager.DupPoint = this.dupPoint;
		if (rigiB) {
			RailDrawManager.Manager.rigidTempB = rigiB;
		}
		rigiB = null;
		return this.temp;

	}
}
