using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_controller : MonoBehaviour {

	static Animator animator; 
	float speed = 0.0f;
	public float delta_speed = 1.0f;
	public float delta_degree = 45;

	private int max_rotate_up_down = 50;
	private int rotate_up_down = 0;

	float max_speed = 5.0f;

	// Use this for initialization
	void Start () {
		animator = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey (KeyCode.LeftArrow)) 
		{
			transform.RotateAround (transform.position + transform.up * 0.8f, Vector3.up, -delta_degree * Time.deltaTime);
		}
		if (Input.GetKey (KeyCode.RightArrow)) 
		{
			transform.RotateAround (transform.position + transform.up * 0.8f, Vector3.up, delta_degree * Time.deltaTime);
		}
		if (Input.GetKey (KeyCode.UpArrow)) 
		{
			if (rotate_up_down + 1 >= -max_rotate_up_down && rotate_up_down + 1 <= max_rotate_up_down) {
				rotate_up_down++;
				transform.RotateAround (transform.position + transform.up * 0.8f, transform.right, -delta_degree * Time.deltaTime);
			}
		}
		if (Input.GetKey (KeyCode.DownArrow)) 
		{
			if (rotate_up_down - 1 >= -max_rotate_up_down && rotate_up_down - 1 <= max_rotate_up_down) {
				rotate_up_down--;
				transform.RotateAround (transform.position + transform.up * 0.8f, transform.right, delta_degree * Time.deltaTime);
			}
		}
		if (Input.GetKey ("w")) 
		{
			speed += delta_speed * Time.deltaTime;
			if (speed > max_speed) {
				speed = max_speed;
			}
		}
		if (Input.GetKey ("s")) 
		{
			speed -= delta_speed * Time.deltaTime;
			if (speed < 0) {
				speed = 0;
			}
		}

		transform.position += transform.forward * speed * 2 * Time.deltaTime;
		animator.speed = speed;
	}
}
