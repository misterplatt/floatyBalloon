using UnityEngine;
using System.Collections;

public class balloon_controller : MonoBehaviour {

	Rigidbody2D r;

	public float floatSpeed;
	public float dropPerTouch = -50;
	public float dropPerClick = -30;
	public float addLRSpeed = 5;
	public float maxLRSpeed = 10;

	public AudioClip pop;

	// Use this for initialization
	void Start () {
		r = GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void Update () {

		//Mobile Dropping
		if (Input.GetMouseButton(0)) {
			r.AddForce(new Vector2 (0, dropPerTouch));		
		}
		//PC Dropping
		if (Input.GetKey (KeyCode.Space)) {
			r.AddForce(new Vector2 (0, dropPerClick));		
		}
		
	}

	void FixedUpdate () {

		//L/R Mobile code
		//Check that tilting is intentional (reads higher than .1f)
		if (Mathf.Abs (Input.acceleration.x) > 0.1f) {

			//float xDir = Mathf.Sign (Input.acceleration.x);
			float xDir = Input.acceleration.x;
			if(xDir > 0){
				if(r.velocity.x <= maxLRSpeed)
					r.AddForce(new Vector2 (xDir * 7, 0));
			} 
			else if(xDir < 0){
				if(r.velocity.x > -maxLRSpeed)
					r.AddForce(new Vector2 (xDir * 7, 0));
			}
		}


		//L/R PC code
		float moveH = Input.GetAxis ("Horizontal");
		//Debug.Log (moveH);
		if(moveH > 0){
			if(r.velocity.x <= maxLRSpeed)
				r.AddForce(new Vector2 (moveH * addLRSpeed, 0));
		} 
		else if(moveH < 0){
			if(r.velocity.x > -maxLRSpeed)
				r.AddForce(new Vector2 (moveH * addLRSpeed, 0));
		}
		
	}

	void OnCollisionEnter2D(Collision2D col) {
		if (col.gameObject.tag == "popper") {
			AudioSource.PlayClipAtPoint(pop, transform.position);
			gameObject.SetActive(false);
			Invoke ("reload", .75f);
		}
	}

	void reload(){
		Application.LoadLevel(Application.loadedLevelName);
	}

}
