using UnityEngine;
using System.Collections;

public class RaycastNavigation : MonoBehaviour {

	public Actor actor;
	public int button=0;
	public float tolerance = 0.01f;

	// not correct if selection is moving
	private Vector3 target;

	void Update () {
	
		if (Input.GetMouseButton(button)) {

			Debug.Log ("button is held down");
			Vector3 pos=Input.mousePosition;
			Ray R = Camera.main.ScreenPointToRay(pos);
			RaycastHit info;
			bool didHit = Physics.Raycast (R,out info);
			if(!didHit){
				Debug.Log ("no hit");
				return;
			}
			target = info.point;

		}

		Vector3 u = target-actor.transform.position;
		if (u.magnitude <= tolerance) {
			return;
		}

		u.Normalize ();		
		actor.Move (u);

	}
}
