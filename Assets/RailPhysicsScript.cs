using UnityEngine;
using System.Collections;

public class RailPhysicsScript : MonoBehaviour
{
	public Rigidbody2D rg2d;
	public FixedJoint2D fixjoint2D, fixJoint2D_B;

	public void SetInfoFixedJoint (Rigidbody2D rg)
	{
		fixjoint2D.connectedBody = rg;
	}

	public void SetInfoFixedJoint_B (Rigidbody2D rg)
	{
		fixJoint2D_B.connectedBody = rg;
	}

	void Update ()
	{
		if (Input.GetKeyDown (KeyCode.Space)) {
			if (rg2d.isKinematic) {
				rg2d.isKinematic = false;
				if (this.transform.position.y  < 4.6f) {
					if (this.transform.position.y > 4.4f) {
						this.gameObject.layer = LayerMask.NameToLayer ("RAILPHYSICS");
					}
				}
			}
		}
	}
}
