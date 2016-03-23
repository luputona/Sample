using UnityEngine;
using System.Collections;

public class PlayerCtrl : MonoBehaviour
{


	private Rigidbody myBody;
	private bool facingRight;
	private Animator myAnim;
	private Vector3 tempVec;

	public float gravity = -12.0f;
	public GUI left;
	public GUI right;
	public Vector3 lookDiretion;
	public float speed = 0.0f;
	public float walkSpeed = 3.0f;
	public float runSpeed = 5.5f;
	public float jump = 50.0f;
	public bool isGround;
	public bool canMoveInAir = true;
	public GroundCheck cGroundCheck;
	public Chat chatCommand;


	// Use this for initialization
	void Start ()
	{
		tempVec = this.transform.position;
		myAnim = GetComponent<Animator> ();
		myBody = GetComponent<Rigidbody> ();

		facingRight = true;



	}
	
	// Update is called once per frame
	void Update ()
	{

	}

	void FixedUpdate ()
	{
		PlayerControl ();
		Jump ();
		Attack ();

	}

	void PlayerControl ()
	{

		float move = Input.GetAxisRaw ("Horizontal");
		myAnim.SetFloat ("speed", Mathf.Abs (move));

		float sneaking = Input.GetAxisRaw ("Fire3");
		myAnim.SetFloat ("sneaking", sneaking);

		if (sneaking > 0) 
		{
			myBody.velocity = new Vector3 (move * walkSpeed, myBody.velocity.y, 0);
		} 
		else 
		{
			myBody.velocity = new Vector3 (move * runSpeed, myBody.velocity.y, 0);
		}
			
		if (move > 0 && !facingRight) 
		{
			Flip ();
		} 
		else if (move < 0 && facingRight) 
		{
			Flip ();
		}

		if (Input.GetKeyDown(KeyCode.DownArrow)) 
		{
			StartCoroutine (Landing());

		} 
	


		if (chatCommand.input.text == "1" || Input.GetKeyDown(KeyCode.Equals)) 
		{
			Debug.Log("escape");
			this.transform.position = tempVec;
		}


	}

	void Flip ()
	{
		facingRight = !facingRight;
		Vector3 theScale = transform.localScale;
		theScale.z *= -1;
		transform.localScale = theScale;

	}

	void Jump ()
	{
		isGround = cGroundCheck.isDownCheckGround;
		if (isGround && Input.GetKeyDown (KeyCode.Space)) 
		{
			Debug.Log ("jump");
			myAnim.SetBool ("Jump",true);
			myBody.AddForce (Vector3.up * jump, ForceMode.VelocityChange);
		} 
		else 
		{
			Physics.gravity = new Vector3 (0f, gravity, 0f);
			myAnim.SetBool ("Jump",false);
		}

	}

	void Attack()
	{
		isGround = cGroundCheck.isDownCheckGround;
		if (Input.GetKeyDown (KeyCode.Z)&& isGround) 
		{
			myAnim.SetBool ("Jab", true);

		} 
		else 
		{
			myAnim.SetBool ("Jab", false);
		}

		if (Input.GetKeyDown (KeyCode.X) && isGround) 
		{
			myAnim.SetBool ("Kick", true);
			walkSpeed = 0.0f;
			runSpeed = 0.0f;
		} 
		else 
		{
			myAnim.SetBool ("Kick", false);
		}

		if (Input.GetKeyDown (KeyCode.C) && isGround) 
		{
			myAnim.SetBool ("Samk", true);
			walkSpeed = 0.0f;
			runSpeed = 0.0f;
		} 
		else 
		{
			myAnim.SetBool ("Samk", false);
		}


	}


	void OnCollisionEnter(Collision coll)
	{
		if (coll.gameObject.tag == "JumpGround" && !canMoveInAir && !isGround)
		{
			walkSpeed = 0.0f;
			runSpeed = 0.0f;
		} 
		else 
		{
			walkSpeed = 2.0f;
			runSpeed = 5.0f;
		}
	}

	IEnumerator Landing()
	{
		yield return new WaitForSeconds(0.32f);
		myAnim.SetBool ("landing", true);
		walkSpeed = 0.0f;
		runSpeed = 0.0f;
		yield return new WaitForSeconds(0.1f);
		myAnim.SetBool ("landing",false);

	}

}


























