using UnityEngine;
using System.Collections;

public class AnalogStickView : MonoBehaviour {

	public VirtualAnalogStick source;
	private Vector2 origin;

	void Start(){

		RectTransform T = GetComponent<RectTransform> ();
		origin=T.position;
		T.position = source.stickCoordinates;

	}

	// Update is called once per frame
	void Update () {

		RectTransform T = GetComponent<RectTransform> ();
		T.position = origin+source.stickPosition;
		T.position = source.stickCoordinates;

	}
}
