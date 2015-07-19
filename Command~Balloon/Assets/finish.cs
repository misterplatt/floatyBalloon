using UnityEngine;
using System.Collections;

public class finish : MonoBehaviour {

	public float levelNumber;
	public AudioClip victory;
	public GameObject player;

	bool freeze = false;

	// Use this for initialization
	void Start () {
		player = GameObject.Find ("balloon");
	}
	
	// Update is called once per frame
	void Update () {
		if (freeze) {
			player.GetComponent<Rigidbody2D>().isKinematic = true;			
		}
	}

	void OnTriggerEnter2D(Collider2D hit) {
		freeze = true;
		AudioSource.PlayClipAtPoint (victory, transform.position);
		Invoke ("nextLevel", 1f);
	}

	void nextLevel () {
		Application.LoadLevel ("Level" + levelNumber);
	}


}
