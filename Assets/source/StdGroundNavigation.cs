using UnityEngine;
using System.Collections;

public class StdGroundNavigation : MonoBehaviour {

	public Actor target;
	public VirtualAnalogStick dpad;

	void Update () {
	
		Vector2 input = new Vector2(Input.GetAxis("Horizontal"),Input.GetAxis ("Vertical"));

		if (dpad != null && dpad.isDragging) {
			input = dpad.value;
		}

		float magnitude = input.magnitude;

		Vector3 direction = new Vector3 (input.x, input.y, input.y);

		direction = transform.TransformDirection (direction);
		direction.y = 0.0f;
		direction.Normalize();
		direction *= magnitude;

		target.Move (direction);

	}

}
