using UnityEngine;
using System.Collections;

public class GroundCollisionCheck : MonoBehaviour {

	private BoxCollider[] boxColl;
	public GroundCheck cgroundCheck;
	float tempTime;
	
	// Use this for initialization
	void Start () {
		boxColl = gameObject.GetComponentsInChildren<BoxCollider> ();

	}
	
	// Update is called once per frame
	void Update () {
		CheckColl ();

	}

	void CheckColl()
	{
		//isPlayer = cgroundCheck.isCheckGroud;

		foreach(BoxCollider groundColl in boxColl )
		{
			if (cgroundCheck.isUpCheckGround == true && Input.GetKey(KeyCode.Space) )
			{ 
				groundColl.isTrigger = true;

			}
			else if(cgroundCheck.isDownCheckGround == true &&  Input.GetKey(KeyCode.DownArrow))
			{
				groundColl.isTrigger = true;

			}
			else if ( cgroundCheck.isDownCheckGround == true )
			{
				groundColl.isTrigger = false;						

			} 

		}

	}

}
