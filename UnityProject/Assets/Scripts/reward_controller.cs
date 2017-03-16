using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class reward_controller : MonoBehaviour {

	public float time_floating;
	public float speed_floating;

	private bool exist;

	// Use this for initialization
	void Start () {
		Destroy(gameObject, time_floating);
	}
	
	// Update is called once per frame
	void Update () {
		transform.position += Vector3.up * Time.deltaTime * speed_floating;
	}
}
