using UnityEngine;
using System.Collections;

public class laser_gun : MonoBehaviour {

	public GameObject laser;
	private GameObject shootFrom = null;
	private GameObject fire = null;

	private bool laserReady = true;
	private float laserCD = 3f;

	// Use this for initialization
	void Start () {
		shootFrom = GameObject.Find("barrelTip");
	}
	
	// Update is called once per frame
	void Update () {
		if (laserReady) {
			fire = Instantiate(laser, shootFrom.transform.position, Quaternion.identity) as GameObject;
			laserReady = false;
			Invoke ("laserOff", laserCD);
		}
	}

	void laserOff () {
		Destroy (fire);
		Invoke ("laserOn", laserCD);
	} 

	void laserOn () {
		laserReady = true;
	}
}
