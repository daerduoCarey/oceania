using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cam_player_text: MonoBehaviour {

	public bool start_activation;
	Renderer[] renderers;

	// Use this for initialization
	void Start () {
		renderers = gameObject.GetComponentsInChildren<Renderer>();
		foreach (Renderer r in renderers)
		{
			r.enabled = start_activation;
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown ("c")) {
			start_activation = !start_activation;
			foreach (Renderer r in renderers)
			{
				r.enabled = start_activation;
			}
		}
	}
}
