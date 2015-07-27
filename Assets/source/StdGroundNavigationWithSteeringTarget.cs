using UnityEngine;
using System.Collections;

public class StdGroundNavigationWithSteeringTarget : MonoBehaviour {

	public enum VerticalAxisConversion
	{ yAxis,zAxis }

	public Actor target;

	void Update () {
	
		Vector2 input = new Vector2 (Input.GetAxis("Horizontal"), Input.GetAxis ("Vertical"));

		Transform T = transform;
		Transform R = T.parent;

		float magnitude = input.magnitude;
		if (magnitude>1.0f) magnitude = 1.0f;

		T.localPosition = new Vector3 (input.x, 0.0f, input.y);

		Vector3 O = R.position;
		Vector3 P = T.position;

		T.position = new Vector3 ( P.x, O.y, P.z );

		Vector3 direction = T.position-R.position;

		direction.Normalize ();
		direction*=magnitude;

		target.Move (direction);

	}

}
