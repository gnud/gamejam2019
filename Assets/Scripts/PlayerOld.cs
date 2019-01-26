using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerOld : MonoBehaviour {

	public float movementSpeed = 10f;
	public Text xxx;
	Rigidbody2D rb;


	float movement = 0f;
	float maxX = 2.5f;
	float minX = -2.5f;

	bool isLeftEnabled = true ,isRightEnabled = true;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
		movePlayer();
		movement = Input.GetAxis("Horizontal") * movementSpeed;	
	}

	void movePlayer(){
			if(Input.GetKey("a")){
				if(isLeftEnabled){
       			transform.Translate(new Vector3(-1, 0, 0) * Time.deltaTime * 5);	
				}
			}

			if(Input.GetKey("d")){
				
				if(isRightEnabled){
       			transform.Translate(new Vector3(1, 0, 0) * Time.deltaTime * 5);
				}
			}
				
	}
	void FixedUpdate()
	{
		Vector2 velocity = rb.velocity;
		velocity.x = movement;
		rb.velocity = velocity;
	}

	/// <summary>
	/// OnBecameInvisible is called when the renderer is no longer visible by any camera.
	/// </summary>
	void OnBecameInvisible()
	{
		Destroy(gameObject);
	}

	void onPowerUP(){
		//ToDo:: Change Player Asset  and Update The Velocity of the Jump
	}
}
