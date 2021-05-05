using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTorchScript : MonoBehaviour {

	float dirX, dirY;
	public float moveSpeed = 2f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		dirX = Input.GetAxis ("Horizontal");
		dirY = Input.GetAxis ("Vertical");
		transform.position = new Vector2 (
			transform.position.x + dirX * Time.deltaTime * moveSpeed,
			transform.position.y + dirY * Time.deltaTime * moveSpeed);
	}
}
