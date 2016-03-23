using UnityEngine;
using System.Collections;

public class GroundCheck : MonoBehaviour {

	private BoxCollider boxColl;
	private RaycastHit hit;
	private Vector3 vec;


	public bool isUpCheckGround = false;
	public bool isDownCheckGround = false;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame`
	void Update () {
		RayUpChecking ();
		RayDownChecking ();
	}

	void RayUpChecking()
	{
		//RaycastHit hit;
		vec = transform.position;

		vec.y += 1.0f;
		Physics.Raycast (vec, Vector3.up, out hit, 2.0f);


		Debug.DrawRay(vec, Vector3.up ,Color.red, 2.0f);

		if (hit.collider) 
		{
			if(hit.collider.tag == "JumpGround" )
			{
				isUpCheckGround = true;
				Debug.Log("Up check");
			}
		}
		else
			isUpCheckGround = false;
	}
	void RayDownChecking()
	{

		vec = transform.position;		

		vec.y += 0.5f;
		Physics.Raycast (vec, Vector3.down , out hit, 0.7f);

		//Debug.DrawRay(vec, Vector3.down ,Color.red, 1.0f);

		if (Input.GetKey (KeyCode.DownArrow)) 
		{
			Physics.Raycast (vec, Vector3.up , out hit , 0.0f);
		}
		else if (hit.collider) 
		{
			if(hit.collider.tag == "JumpGround" || hit.collider.tag == "ground" )
			{
				isDownCheckGround = true;
				Debug.Log("Down check");
			}
		}
		else
			isDownCheckGround = false;
	}


}








