using UnityEngine;
using System.Collections;

public class PointRailTempScript : MonoBehaviour {
	public Rigidbody2D rg2d;
	GameObject tilePoint;
	public void TiltePointStatus(GameObject go,bool state){
		this.tilePoint = go;
		this.tilePoint.SetActive (state);
	}
	void Update(){
		if (Input.GetKeyDown (KeyCode.Space)) {
			if (rg2d.isKinematic) {
				rg2d.isKinematic = false;
			}
		}
	}
}
