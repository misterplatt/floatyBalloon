using UnityEngine;
using System.Collections;

public class wall_texture : MonoBehaviour {

	// Use this for initialization
	void Start () {
		transform.renderer.material.mainTextureScale = new Vector2(5 ,5);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
