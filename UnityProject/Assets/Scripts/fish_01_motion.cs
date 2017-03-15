using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Runtime.InteropServices;

public class fish_01_motion : MonoBehaviour {
	System.Random r;

	public float speed;
	int minSpeed = 5;
	int maxSpeed = 10;
	float rotationSpeed = 5.0f;
	float neighbourDistance = 4.0f;
	Vector3 averageHeading;
	Vector3 averagePosition;

	public Vector3 newGoalPos;

	bool turning = false;

	public  AudioClip hit_music;
	private AudioSource source;
	int fishscore = 10;

	// Use this for initialization
	void Start () {
		r = new System.Random();
		speed = 0.2f * r.Next (minSpeed,maxSpeed);
		//this.GetComponent<Animation> () ["swim"].speed = speed;
		source = GetComponent<AudioSource> ();

	}

	void OnTriggerEnter(Collider other){
		if (!turning) {
			newGoalPos = this.transform.position - other.gameObject.transform.position;
			if (other.gameObject.name == "fish_spear1(Clone)") {
				source.PlayOneShot (hit_music, 1F);
				scoreManager.score += fishscore;
				return;
			}
		}
		turning = true;
	}

	void OnTriggerExit(Collider other){
		turning = false;
	}


	void Update () {
		
		float dt = Time.deltaTime;

		if (turning) {
			Vector3 direction0 = newGoalPos - transform.position;
			transform.rotation = Quaternion.Slerp (transform.rotation, Quaternion.LookRotation (direction0), rotationSpeed * dt);
			speed = 0.1f * r.Next (4,8);
		} else {
			if (r.Next (0,4) < 1) {
				applyRules ();
			}
		}

		transform.Translate(-1.5f*dt*speed,0,0);

	}

	void applyRules(){
		GameObject[] gos;
		gos = SpawnerScript.allFish_01;
		//int nFish = SpawnerScript.numFish;

		Vector3 vCenter = Vector3.zero;
		Vector3 vAvoid = Vector3.zero;
		float gSpeed = 0.1f;

		Vector3 goalPos = SpawnerScript.goalPos_01;
		float dist;

		int groupSize = 0;

		foreach (GameObject go in gos) {
			if (go != this.gameObject) {
				dist = Vector3.Distance (go.transform.position, this.transform.position);
				if (dist < neighbourDistance) {
					vCenter += go.transform.position;
					groupSize++;

					if (dist < 2.0f) {
						vAvoid = vAvoid + (this.transform.position - go.transform.position);
					}

					fish_01_motion anotherFlock = go.GetComponent<fish_01_motion> ();
					gSpeed = gSpeed + anotherFlock.speed;
				}
			}
		}

		if (groupSize > 0) { //the fish is in a group
			vCenter = vCenter / groupSize + (goalPos - this.transform.position);
			speed = gSpeed / groupSize;
			//this.GetComponent<Animation> () ["swim"].speed = speed;
			//speed *= .5;
			Vector3 direction = (vCenter + vAvoid) - transform.position;
			if (direction != Vector3.zero)
				transform.rotation = Quaternion.Slerp (transform.rotation, Quaternion.LookRotation (direction), rotationSpeed * Time.deltaTime);
		}

	}
}
