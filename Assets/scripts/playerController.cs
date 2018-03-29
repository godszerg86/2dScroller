using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour {

	public float maxSpeed = 10f;
	bool facingRight = true;
	Rigidbody2D rb;

	Animator aniM;

	bool grounded = false;
	public Transform groundCheck;
	float groundRadius = 0.2f;
	public LayerMask whatIsGround;
	public float jumpForce = 700f;


	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D> ();
		aniM = GetComponent<Animator> ();
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		grounded = Physics2D.OverlapCircle (groundCheck.position, groundRadius, whatIsGround);
		aniM.SetBool ("Ground", grounded);
		aniM.SetFloat("vSpeed", rb.velocity.y);




		if (!grounded) return;
		float move = Input.GetAxis ("Horizontal");
		aniM.SetFloat ("Speed", Mathf.Abs (move));
		rb.velocity = new Vector2 (move * maxSpeed, rb.velocity.y);

		if (move > 0 && !facingRight)
			Flip ();
		else if (move < 0 && facingRight)
			Flip ();
			
}

void Update () {

	if (grounded && Input.GetKeyDown("space")){

		aniM.SetBool("Ground", false);
		rb.AddForce(new Vector2(0f,jumpForce));
	}



}


	void Flip() {
		facingRight = !facingRight;
		Vector3 theScale = transform.localScale;  
		theScale.x *= -1;
		transform.localScale = theScale;

	}
}