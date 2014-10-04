using UnityEngine;
using System.Collections;

public class finish : MonoBehaviour {

	public float levelNumber;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D hit) {
		if (levelNumber == 1) {
			Application.LoadLevel ("Level2");	
		} else if (levelNumber == 2) {
			Application.LoadLevel ("Level3");	
		} else if (levelNumber == 3) {
			Application.LoadLevel ("Level4");	
		} else if (levelNumber == 4) {
			Application.LoadLevel ("Level5");	
		} else if (levelNumber == 5) {
			Application.LoadLevel ("Level6");	
		} 
	}

}
