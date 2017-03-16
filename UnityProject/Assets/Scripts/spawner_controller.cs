using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class spawner_controller : MonoBehaviour {

	public AudioClip shoot1;
	public AudioClip shoot2;
	public AudioClip shoot3;
	public AudioClip shoot4;

	public AudioClip no_spear_sound;

	private AudioClip[] shoot_sounds;

	private AudioSource source;

	public GameObject fish_spear1;
	public GameObject fish_spear2;
	public GameObject fish_spear3;
	public GameObject fish_spear4;

	private GameObject [] object_prefabs;
	private static int num_spears = 4;

	private int cur_spear = 0;

	private static System.Random getrandom = new System.Random();

	// Use this for initialization
	void Start () {
		object_prefabs = new GameObject[num_spears];
		shoot_sounds = new AudioClip[num_spears];

		object_prefabs [0] = fish_spear1; shoot_sounds [0] = shoot1;
		object_prefabs [1] = fish_spear2; shoot_sounds [1] = shoot2;
		object_prefabs [2] = fish_spear3; shoot_sounds [2] = shoot3;
		object_prefabs [3] = fish_spear4; shoot_sounds [3] = shoot4;

		camera_spears_selector.pick_or_not [0] = true;

		source = GetComponent<AudioSource> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Space)) {
			if (spear_num_left_controller.num_spears_left [cur_spear] > 0) {
				--spear_num_left_controller.num_spears_left [cur_spear];
				if (cur_spear == 2) {
					for (int sid = 0; sid <= 10; ++sid) {
						Vector3 pos = transform.position + transform.up * 0.5f;
						pos += transform.right * ((float)getrandom.NextDouble () * 5.0f - 2.5f);
						pos += transform.forward * ((float)getrandom.NextDouble () * 5.0f - 2.5f);
						Instantiate (object_prefabs [cur_spear], pos, transform.rotation);
					}
					source.PlayOneShot (shoot_sounds [cur_spear], 1F);
				} else if (cur_spear == 3) {
					for (int sid = 0; sid <= 100; ++sid) {
						Vector3 pos = transform.position + transform.up * 0.5f;
						pos += transform.right * ((float)getrandom.NextDouble () * 10f - 5f);
						pos += transform.forward * ((float)getrandom.NextDouble () * 10f - 5f);
						Instantiate (object_prefabs [cur_spear], pos, transform.rotation);
					}
					source.PlayOneShot (shoot_sounds [cur_spear], 1F);
				} else {
					Vector3 pos = transform.position + transform.up * 0.5f;
					Instantiate (object_prefabs [cur_spear], pos, transform.rotation);
					source.PlayOneShot (shoot_sounds [cur_spear], 1F);
				}
			} else {
				source.PlayOneShot (no_spear_sound, 1F);
			}
		}
		if (Input.GetKeyDown ("q")) {
			camera_spears_selector.pick_or_not [cur_spear] = false;
			cur_spear = (cur_spear + num_spears - 1) % 4;
			camera_spears_selector.pick_or_not [cur_spear] = true;
		}
		if (Input.GetKeyDown ("e")) {
			camera_spears_selector.pick_or_not [cur_spear] = false;
			cur_spear = (cur_spear + 1) % 4;
			camera_spears_selector.pick_or_not [cur_spear] = true;
		}
	}
}
