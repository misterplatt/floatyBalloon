using UnityEngine;
using System.Collections;

public class Camera2D : MonoBehaviour {

	//Camera Tracking Variables
	public Transform player;
	public float smoothrate = 0.5f;
	
	private Transform thisTransform;
	private Vector2 velocity;

	//Zoom variables
	private float cameraPosition = 0;

	public float zoomInSpeed = 0.4f;
	public float timeBeforeZoomIn = 1f;
	public float zoomTime = 1f;

	private static float targetCameraPosition;
	private Vector2 cameraVelocity = new Vector2 (0.5f, 0.5f);
	
	// Use this for initialization
	void Start () {
		thisTransform = transform;
		velocity = new Vector2 (0.5f, 0.5f);
		targetCameraPosition = Camera.main.orthographicSize;
		AudioListener.volume = 0.35f;
		scheduleZoomIn ();
	}
	
	// Update is called once per frame
	void Update () {
		Vector2 newPos2D = Vector2.zero;

		//Omnidirectional tracking
		newPos2D.x = Mathf.SmoothDamp (thisTransform.position.x, player.position.x, ref velocity.x, smoothrate);
		newPos2D.y = Mathf.SmoothDamp (thisTransform.position.y, player.position.y, ref velocity.y, smoothrate);

		//Update the camera
		Vector3 newPos = new Vector3 (newPos2D.x, newPos2D.y, transform.position.z);
		transform.position = Vector3.Slerp (transform.position, newPos, Time.time);
		cameraPosition = Camera.main.orthographicSize;

		//Adjust ortho size to targetCameraPosition
		Camera.main.orthographicSize = Mathf.SmoothDamp (cameraPosition, targetCameraPosition, ref cameraVelocity.y, zoomTime);
	}
	
	void zoomIn () {
		targetCameraPosition = 25f;
	}
	
	void scheduleZoomIn() {
		Invoke ("zoomIn", timeBeforeZoomIn);
	}
}
