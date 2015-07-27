using UnityEngine;
using System.Collections;

public class VirtualAnalogStick : MonoBehaviour {

	public int button = 0;

	public Vector2  centre = new Vector2 (0.2f, 0.2f);
	public float    activeRadius = 64.0f;
	public float    effectRadius = 32.0f;

	// for debugging ---------------------------------------

	public Vector2 mouse;
	public bool inside = false;
	public float distance = 0.0f;

	// private variables ------------------------------------

	private Vector2 activeOrigin;
	private Vector2 activeTarget;
	public bool dragging = false;

	// properties -------------------------------------------

	// on-screen pivot coordinates
	public Vector2 pivotCoordinates {
		get {
			return new Vector2 (Screen.width * centre.x, Screen.height * centre.y);
		}
	}

	// on-screen stick coordinates
	public Vector2 stickCoordinates { 
		get{ 
			return pivotCoordinates+stickPosition;
		} 
	}

	/**
	 * The position of the stick relative to the pivot (in pixels)
	 * Use this to update visual representation of the stick (if any)
	 */
	public Vector2 stickPosition	{ 
		get{ 
			Vector2 u = activeTarget-activeOrigin;
			float m = u.magnitude;
			if(m>effectRadius)m=effectRadius;
			u.Normalize();
			return u*m;
		} 
	}
	
	/** 
	 * The input delivered by the dpad (fractional).
	 * Use this to steer game actors
	 */
	public Vector2 value	{ 
		get{ 
			return stickPosition / effectRadius; 
		}
	}

	public bool isDragging{
		get{
			return dragging;
		}
	}

	// functions --------------------------------------------

	void Update () {

		mouse = Input.mousePosition;
		inside = isWithinActiveArea (mouse);
		distance = distanceFromCenter (mouse);

		if (Input.GetMouseButtonDown (button)) {

			// on mouse down, set dragging origin
			if (!inside) return;
			dragging = true;
			Vector2 P = Input.mousePosition; 
			activeOrigin.x = P.x;
			activeOrigin.y = P.y;


		} else if (Input.GetMouseButtonUp (button)) {

			// on mouseup, disable dragging
			dragging = false;
			activeTarget = activeOrigin;
			
		} else if (dragging) {

			// while dragging, update target position
			Vector2 P = Input.mousePosition; 
			activeTarget.x = P.x;
			activeTarget.y = P.y;

		}

	}

	private float distanceFromCenter(Vector2 P){
		
		return (P-pivotCoordinates).magnitude;
		
	}

	private bool isWithinActiveArea(Vector2 P){
	
		return (P-pivotCoordinates).magnitude<=activeRadius;

	}

}
