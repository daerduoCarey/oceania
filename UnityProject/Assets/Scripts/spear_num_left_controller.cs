using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spear_num_left_controller : MonoBehaviour {

	public static int[] num_spears_left;
	private TextMesh text;
	public int spear_id;

	// Use this for initialization
	void Start () {
		num_spears_left = new int[4] {100, 50, 20, 10};
		text = gameObject.GetComponent ("TextMesh") as TextMesh;
	}
	
	// Update is called once per frame
	void Update () {
		text.text = "" + num_spears_left [spear_id];
	}
}
