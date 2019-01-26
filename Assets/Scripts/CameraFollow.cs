using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

	public Transform target;
	public GameObject gameOverText;


	void onStart(){
		
	}
	void LateUpdate () {
		if (target == null)
		{
			gameOverText.SetActive(true);
		}else
		{
			gameOverText.SetActive(false);
			if (target.position.y > transform.position.y)
		{
			Vector3 newPos = new Vector3(transform.position.x, target.position.y, transform.position.z);
			transform.position = newPos;
		}
		}
		
	}
}
