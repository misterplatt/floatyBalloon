using UnityEngine;
using System.Collections;

public class balloon_controller : MonoBehaviour {

	public float floatSpeed;
	public float dropPerClick;
	public float addLRSpeed;
	public float maxLRSpeed;

	public AudioClip pop;

	// Use this for initialization
	void Start () {
	//Mobile initializations
		/*
		Screen.orientation = ScreenOrientation.LandscapeLeft;
		Screen.autorotateToLandscapeLeft = true;
		Screen.autorotateToLandscapeRight = false;
		Screen.autorotateToPortrait = false;
		Screen.autorotateToPortraitUpsideDown = false;
		Screen.orientation = ScreenOrientation.AutoRotation;
		*/
	}
	
	// Update is called once per frame
	void Update () {
	
	//Commented out what I tried for mobile controls
		/*
		Screen.orientation = ScreenOrientation.LandscapeLeft;
		Vector3 dir = Vector3.zero;

		foreach(Touch tap in Input.touches) {
			if (tap.phase == TouchPhase.Began) {
				Debug.Log ("We touched");
				rigidbody2D.AddForce(new Vector2(0, -100));
			}
		}

		dir.x = Input.acceleration.x;
		dir.y = -Input.acceleration.y;

		if (dir.sqrMagnitude > 1) {
			dir.Normalize ();
		}

		dir *= Time.deltaTime;
		transform.Translate (dir * maxLRSpeed);
		*/
		
		//Normal PC control
		if (Input.GetKey (KeyCode.Space)) {
			rigidbody2D.AddForce(new Vector2 (0, -30));		
		}
		
	}

	void FixedUpdate () {
		
		//L/R code
		float moveH = Input.GetAxis ("Horizontal");
		if(moveH > 0)
		{
			if(rigidbody2D.velocity.x <= maxLRSpeed)
				rigidbody2D.AddForce(new Vector2 (moveH * addLRSpeed, 0));
		} 
		else if(moveH < 0)
		{
			if(rigidbody2D.velocity.x > -maxLRSpeed)
				rigidbody2D.AddForce(new Vector2 (moveH * addLRSpeed, 0));
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
