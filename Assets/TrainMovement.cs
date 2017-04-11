using UnityEngine;
using System.Collections;

public class TrainMovement : MonoBehaviour
{
	public Rigidbody2D rg2d;
	public float moveSpeed;
	bool move = false;
	public Transform checkGround;
	LayerMask maskGround;
	void Start(){
		maskGround = LayerMask.NameToLayer ("RAILPHYSICS");
	}
	void Update ()
	{
		if (Input.GetKeyDown (KeyCode.Space)) {
			move = true;
		}
	}
	void FixedUpdate ()
	{
		if (move) {
			if (Physics2D.Linecast (this.transform.position, checkGround.position, 1 << maskGround)) {
				rg2d.velocity = new Vector2 (moveSpeed, rg2d.velocity.y);
			}
		}
	}
}
