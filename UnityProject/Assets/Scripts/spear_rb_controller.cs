using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spear_rb_controller : MonoBehaviour {

	private Rigidbody rb;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody>();
		rb.velocity = transform.forward * 20;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
