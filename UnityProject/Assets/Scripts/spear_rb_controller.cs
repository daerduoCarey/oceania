using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spear_rb_controller : MonoBehaviour {

	private Rigidbody rb;

	public  AudioClip hit_music;
	private AudioSource source;

	public float init_speed;

	public GameObject instance_score_prefab;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody>();
		rb.velocity = transform.forward * init_speed;
		source = GetComponent<AudioSource> ();
	}

	void OnTriggerEnter(Collider other){
		//print (other.gameObject.name);
		if (other.gameObject.CompareTag( "fish")) {
			source.PlayOneShot (hit_music, 1F);
			scoreManager.score += 10;
			other.gameObject.SetActive (false);
			Instantiate(instance_score_prefab, other.gameObject.transform.position, transform.rotation);
			return;
		}
	}


	// Update is called once per frame
	void Update () {
		
	}
}
