using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class spawner_controller : MonoBehaviour {

	public AudioClip shoot;
	private AudioSource source;

	public GameObject fish_spear1;

	private GameObject [] object_prefabs;
	public int number;

	// Use this for initialization
	void Start () {
		object_prefabs = new GameObject[1];
		//object_prefabs [0] = Resources.Load<GameObject> ("Prefabs/fish_spear1");
		object_prefabs [0] = fish_spear1;
		number = 0;
		source = GetComponent<AudioSource> ();

	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetKeyDown (KeyCode.Space)) {
			Instantiate(object_prefabs[0], transform.position + transform.up * 0.5f, transform.rotation);
			++number;
			source.PlayOneShot (shoot, 1F);
		}
	}
}
