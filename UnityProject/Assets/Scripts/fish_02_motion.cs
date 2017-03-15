using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Runtime.InteropServices;

public class fish_02_motion : MonoBehaviour {
	System.Random r;

	public float speed;
	float rotationSpeed = 2.0f;
	float neighbourDistance = 6.0f;
	Vector3 averageHeading;
	Vector3 averagePosition;

	bool turning = false;

	public Vector3 newGoalPos;

//	public  AudioClip hit_music;
//	private AudioSource source;
//	int fishscore = 10;

	// Use this for initialization
	void Start () {
		r = new System.Random(Guid.NewGuid().GetHashCode());
		speed = 0.2f * r.Next (5,10);
		//source = GetComponent<AudioSource> ();
	}

	void OnTriggerEnter(Collider other){
//		if (other.gameObject.name == "fish_spear1(Clone)") {
//			source.PlayOneShot (hit_music, 1F);
//			scoreManager.score += fishscore;
//			return;
//		}
		if (!turning) {
			newGoalPos = this.transform.position - other.gameObject.transform.position;
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
			transform.rotation = Quaternion.Slerp (transform.rotation, Quaternion.LookRotation (direction0), 2*rotationSpeed * dt);
			speed = 0.2f * r.Next (7,10);
		} 
			if (r.Next (0,4) < 1) {
				applyRules ();
			}


		transform.Translate(-2.2f*dt*speed,0,0);

	}

	void applyRules(){
		GameObject[] gos;
		gos = SpawnerScript.allFish_02;
		//int nFish = SpawnerScript.numFish;

		Vector3 vCenter = Vector3.zero;
		Vector3 vAvoid = Vector3.zero;
		float gSpeed = 0.1f;

		Vector3 goalPos = SpawnerScript.goalPos_02;
		float dist;

		int groupSize = 0;

		foreach (GameObject go in gos) {
			if (go != this.gameObject) {
				if (!go.activeSelf) {
					continue;
				}
				dist = Vector3.Distance (go.transform.position, this.transform.position);
				if (dist < neighbourDistance) {
					vCenter += go.transform.position;
					groupSize++;

					if (dist < 2.0f) {
						vAvoid = vAvoid + (this.transform.position - go.transform.position);
					}

					fish_02_motion anotherFlock = go.GetComponent<fish_02_motion> ();
					gSpeed = gSpeed + anotherFlock.speed;
				}
			}
		}

		if (groupSize > 0) { //the fish is in a group
			vCenter = vCenter / groupSize + (goalPos - this.transform.position);
			speed = gSpeed / groupSize;
			//speed *= .5;
			Vector3 direction = (vCenter + vAvoid) - transform.position;
			if (direction != Vector3.zero)
				transform.rotation = Quaternion.Slerp (transform.rotation, Quaternion.LookRotation (direction), rotationSpeed * Time.deltaTime);
		}

	}
}
