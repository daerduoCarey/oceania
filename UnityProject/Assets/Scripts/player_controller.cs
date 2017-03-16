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
	float[,] play_area;

	// Use this for initialization
	void Start () {
		animator = GetComponent<Animator> ();
		play_area = new float[3, 2]{ { -59f, 59f }, { -6f, 20f }, { -59f, 59f } };
		spear_num_left_controller.num_spears_left = new int[4] { 100, 20, 10, 1 };
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

		alert_text_manager.alert_message = "Go for the Fishes!";
		if (transform.position.x < play_area [0, 0]) {
			alert_text_manager.alert_message = "Out of Game Boundary!";
			transform.position = new Vector3 (play_area [0, 0], transform.position.y, transform.position.z);
		}
		if (transform.position.x > play_area [0, 1]) {
			alert_text_manager.alert_message = "Out of Game Boundary!";
			transform.position = new Vector3 (play_area [0, 1], transform.position.y, transform.position.z);
		}

		if (transform.position.y < play_area [1, 0]) {
			alert_text_manager.alert_message = "Out of Game Boundary!";
			transform.position = new Vector3 (transform.position.x, play_area [1, 0], transform.position.z);
		}
		if (transform.position.y > play_area [1, 1]) {
			alert_text_manager.alert_message = "Out of Game Boundary!";
			transform.position = new Vector3 (transform.position.x, play_area [1, 1], transform.position.z);
		}

		if (transform.position.z < play_area [2, 0]) {
			alert_text_manager.alert_message = "Out of Game Boundary!";
			transform.position = new Vector3 (transform.position.x, transform.position.y, play_area [2, 0]);
		}
		if (transform.position.z > play_area [2, 1]) {
			alert_text_manager.alert_message = "Out of Game Boundary!";
			transform.position = new Vector3 (transform.position.x, transform.position.y, play_area [2, 1]);
		}

		transform.position += transform.forward * speed * 2 * Time.deltaTime;
		animator.speed = speed;
	}
}
