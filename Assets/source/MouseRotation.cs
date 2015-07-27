using UnityEngine;
using System.Collections;

public class MouseRotation : MonoBehaviour {

	public enum Mode{ AlwaysOn, RotateOnDrag, RotateOnClick }

	// ----------------------------------------------

	public Mode mode = Mode.RotateOnDrag;
	public int button = 0;
	public bool buttonState = false;
	public Vector2 gain = new Vector2(1.0f, -1.0f);
	public VirtualAnalogStick dpad;

	// -----------------------------------------------

	private Vector3 position;
	private Vector3 euler;
	private bool dragging=false;

	Vector3 current{
		
		get{
		
			Vector3 mouse = Input.mousePosition;
			return new Vector3(gain.y*mouse.y, gain.x*mouse.x);

		}
		
	}

	void Start(){

		position = current;

	}

	void Update() {

		if (dpad.isDragging)return;

		UpdateStatus ();

		if (dragging) {
			euler += current - position;
			position = current;
			//
			transform.localEulerAngles = euler;
		}

	}

	void UpdateStatus(){

		buttonState = Input.GetMouseButton (button);

		switch (mode) {

		case Mode.AlwaysOn: 
			dragging=true;
			break;

		case Mode.RotateOnClick:
			if(Input.GetMouseButtonDown (button)){
				dragging=!dragging;
				position=current;
			}
			break;

		case Mode.RotateOnDrag:
			if(Input.GetMouseButtonDown (button)) position=current;
			dragging=Input.GetMouseButton(button);
			break;

		}
		
	}
	
}
