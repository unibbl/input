using UnityEngine;
using System.Collections;

public class AnalogStickView3D : MonoBehaviour {

	public bool facing = true;
	public VirtualAnalogStick source;
	public float scale = 0.1f;
	private Vector2 origin;
	
	void Start(){

		Vector3 osl = Camera.main.WorldToScreenPoint (transform.position);
		osl.x /= Screen.width;
		osl.y /= Screen.height;
		source.centre = osl;

		if (facing) {
			transform.parent.LookAt(Camera.main.transform.position);
			transform.parent.forward = -transform.parent.forward;
		}
		Transform T = GetComponent<Transform> ();
		origin=T.localPosition;

	}

	// Update is called once per frame
	void Update () {

		Transform T = GetComponent<Transform> ();
		T.localPosition = origin+source.stickPosition*scale;

	}
}
