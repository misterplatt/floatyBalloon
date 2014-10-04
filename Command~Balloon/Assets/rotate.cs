using UnityEngine;
using System.Collections;

public class rotate : MonoBehaviour {

	public float rotateSpeed;

	public bool clockwise;
	public bool counterClockwise;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void FixedUpdate (){
		if (clockwise) {
			transform.Rotate (Vector3.forward * -rotateSpeed);
		} else if (counterClockwise) {
			transform.Rotate (Vector3.forward * rotateSpeed);
		}
	}
}
