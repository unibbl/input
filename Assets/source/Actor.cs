using UnityEngine;
using System.Collections;

public class Actor : MonoBehaviour {
	
	public void Move(Vector3 direction){

		transform.position += direction * Time.deltaTime;

	}

}
