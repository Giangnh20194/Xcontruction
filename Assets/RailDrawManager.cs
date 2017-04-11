using UnityEngine;
using System.Collections;


public class RailDrawManager : MonoBehaviour
{
	public TouchControl touchControl;
	public static RailDrawManager Manager;
	public GameObject RailSprite;
	public GameObject PointRailTemp;
	private float _scaleX, _posX;
	private Vector3 _posEnd, _pos;
	private Quaternion _quaTemp;
	public GameObject TilePointCur;
	public bool DupPoint = false;
	public Rigidbody2D rigidTempB;
	void Start ()
	{
		Manager = this;
	}

	public void SetInfoDrawRail (int index, Vector3 pos, Quaternion quaTemp, Vector3 posEnd)
	{

		float posX = ((float)index) * 0.5f;
		float scaleX = 2.5f * (index + 1);

		this._scaleX = scaleX;
		this._posX = posX;
		this._posEnd = posEnd;
		this._pos = pos;
		this._quaTemp = quaTemp;
	}

	public void DrawRailPhysics ()
	{
		this.transform.position = _pos;
		this.transform.rotation = _quaTemp;

		GameObject railTemp = Instantiate (RailSprite) as GameObject;
		railTemp.transform.parent = this.transform;

		railTemp.transform.localPosition = new Vector3 (_posX, 0, 0);
		railTemp.transform.localScale = new Vector3 (_scaleX, 2.2f, 0);
		railTemp.transform.rotation = _quaTemp;
		railTemp.GetComponent<RailPhysicsScript> ().SetInfoFixedJoint (touchControl.rgCurrent);
		if (DupPoint) {
			railTemp.GetComponent<RailPhysicsScript> ().SetInfoFixedJoint_B (rigidTempB);
		}
		touchControl.rgCurrent = null;
		if (!DupPoint) {
			GameObject pointRailTemp = Instantiate (PointRailTemp) as GameObject;
			pointRailTemp.transform.parent = this.transform;
			pointRailTemp.transform.position = _posEnd;
			pointRailTemp.transform.rotation = _quaTemp;
			pointRailTemp.GetComponent<PointRailTempScript> ().TiltePointStatus (TilePointCur, false);
			pointRailTemp.transform.parent = null;
			railTemp.GetComponent<RailPhysicsScript> ().SetInfoFixedJoint_B (pointRailTemp.GetComponent<Rigidbody2D> ());
		}
		railTemp.transform.parent = null;
		DupPoint = false;
		rigidTempB = null;
	}
	//	IEnumerator delay_DrawRailPhysics(ref GameObject rail,ref GameObject point){
	//		yield return new WaitForEndOfFrame ();
	//	}
}
