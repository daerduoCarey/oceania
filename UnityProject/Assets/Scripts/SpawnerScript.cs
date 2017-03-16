using UnityEngine;
using System.Collections;
using System;

public class SpawnerScript : MonoBehaviour {

	public static float rotationSpeed = 4.0f;
	public static float neighbourDistance = 5.0f;
		
	public GameObject fishPrefab;
	public GameObject fishPrefab_01;
	public GameObject fishPrefab_02;
	public GameObject fishPrefab_03;
	public GameObject fishPrefab_04;

	public static int numFish = 0;
	public int numFish_00 = 50;
	public int numFish_01 = 50;
	public int numFish_02 = 50;
	public int numFish_03 = 50;
	public int numFish_04 = 50;

	public GameObject coral_01;
	public int numCoral_01 = 10;

	public static GameObject[] allFish;

	public static GameObject[] allFish_00;
	public static GameObject[] allFish_01;
	public static GameObject[] allFish_02;
	public static GameObject[] allFish_03;
	public static GameObject[] allFish_04;

	public static int tankSize = 50;
	public static int tankSize_y = 7;


	public static Vector3 goalPos = Vector3.zero;
	public static Vector3 goalPos_01 = new Vector3 (-10.0f, 0.0f, 0.0f);
	public static Vector3 goalPos_02 = new Vector3(10.0f, 0.0f, 0.0f);
	public static Vector3 goalPos_03 = new Vector3 (0.0f, 10.0f, 0.0f);
	public static Vector3 goalPos_04 = new Vector3(0.0f, 0.0f, 10.0f);
	System.Random r;

	public  AudioClip back_music;
	private AudioSource source;

	public Color underWaterColor;

	// Use this for initialization
	void Start () {

		RenderSettings.fogColor = underWaterColor;
		RenderSettings.fogDensity = 0.008f;
		RenderSettings.fog = true;

		source = GetComponent<AudioSource> ();
		source.Play ();

		allFish_00 = new GameObject[numFish_00];
		allFish_01 = new GameObject[numFish_01];
		allFish_02 = new GameObject[numFish_02];
		allFish_03 = new GameObject[numFish_03];
		allFish_04 = new GameObject[numFish_04];


		r = new System.Random();

		transform.position = new Vector3(0.0f, 0.0f, 0.0f);
		int initTankSize = 8;
		float delta = 0f;
		for(int i=0; i<numFish_00; i++){
			float x_perturb = r.Next (-initTankSize, initTankSize)*1.0f;
			float y_perturb = r.Next (-tankSize_y, initTankSize)*1.0f;
			float z_perturb = r.Next (-initTankSize, initTankSize)*1.0f;
			Vector3 pos = new Vector3(x_perturb, y_perturb, z_perturb);
			allFish_00[i] = (GameObject) Instantiate(fishPrefab, pos, transform.rotation);
		}
		for(int i=0; i<numFish_01; i++){
			if (i % 20 == 0) {
				delta += 10f;
			}
			float x_perturb = r.Next (-initTankSize, initTankSize)*1.0f;
			float y_perturb = r.Next (-tankSize_y, initTankSize)*1.0f;
			float z_perturb = r.Next (-initTankSize, initTankSize)*1.0f;
			Vector3 pos = new Vector3(x_perturb+delta, y_perturb, z_perturb);
			allFish_01[i] = (GameObject) Instantiate(fishPrefab_01, pos, transform.rotation);
		}
		for(int i=0; i<numFish_02; i++){
			float x_perturb = r.Next (-initTankSize, initTankSize)*1.0f;
			float y_perturb = r.Next (-tankSize_y, initTankSize)*1.0f;
			float z_perturb = r.Next (-initTankSize, initTankSize)*1.0f;
			Vector3 pos = new Vector3(x_perturb+30, y_perturb, z_perturb);
			allFish_02[i] = (GameObject) Instantiate(fishPrefab_02, pos, transform.rotation);
		}
		for(int i=0; i<numFish_03; i++){
			float x_perturb = r.Next (-initTankSize, initTankSize)*1.0f;
			float y_perturb = r.Next (-tankSize_y, initTankSize)*1.0f;
			float z_perturb = r.Next (-initTankSize, initTankSize)*1.0f;
			Vector3 pos = new Vector3(x_perturb, y_perturb, z_perturb-30);
			allFish_03[i] = (GameObject) Instantiate(fishPrefab_03, pos, transform.rotation);
		}
		for(int i=0; i<numFish_04; i++){
			float x_perturb = r.Next (-initTankSize, initTankSize)*1.0f;
			float y_perturb = r.Next (-tankSize_y, initTankSize)*1.0f;
			float z_perturb = r.Next (-initTankSize, initTankSize)*1.0f;
			Vector3 pos = new Vector3(x_perturb-30, y_perturb, z_perturb);
			allFish_04[i] = (GameObject) Instantiate(fishPrefab_04, pos, transform.rotation);
		}


		for(int i=0; i<numCoral_01; i++){
			float x_perturb = r.Next (-initTankSize+30, initTankSize+30)*1.0f;
			float y_perturb = -tankSize_y;
			float z_perturb = r.Next (-initTankSize+30, initTankSize+30)*1.0f;
			delta = 0;
			for (int j = 0; j < 1; j++) {
				Vector3 pos = new Vector3(x_perturb+delta, y_perturb, z_perturb);
				Instantiate(coral_01, pos, transform.rotation);
				pos = new Vector3(x_perturb, y_perturb, z_perturb+delta+1);
				Instantiate(coral_01, pos, transform.rotation);
				delta+=5;
			}
		}
		return;
	}
	
	void Spawn ()
	{
		int initTankSize = 2;
		if (r.Next (0, 500)<1) {			
			for(int i=0; i<numFish_00; i++){
				if (allFish_00 [i].activeSelf) {
					continue;
				}
				float x_perturb = r.Next (-initTankSize, initTankSize)*1.0f;
				float y_perturb = r.Next (-tankSize_y, initTankSize)*1.0f;
				float z_perturb = r.Next (-initTankSize, initTankSize)*1.0f;
				Vector3 pos = new Vector3(x_perturb + 20, y_perturb, z_perturb+20);
				allFish_00[i] = (GameObject) Instantiate(fishPrefab, pos, transform.rotation);
				//print (allFish_00[i].activeSelf);
			}
			for(int i=0; i<numFish_01; i++){
				if (allFish_01 [i].activeSelf) {
					continue;
				}
				float x_perturb = r.Next (-initTankSize, initTankSize)*1.0f;
				float y_perturb = r.Next (-tankSize_y, initTankSize)*1.0f;
				float z_perturb = r.Next (-initTankSize, initTankSize)*1.0f;
				Vector3 pos = new Vector3(x_perturb+10, y_perturb, z_perturb-10);
				allFish_01[i] = (GameObject) Instantiate(fishPrefab_01, pos, transform.rotation);
			}
			for(int i=0; i<numFish_02; i++){
				if (allFish_02 [i].activeSelf) {
					continue;
				}
				float x_perturb = r.Next (-initTankSize, initTankSize)*1.0f;
				float y_perturb = r.Next (-tankSize_y, initTankSize)*1.0f;
				float z_perturb = r.Next (-initTankSize, initTankSize)*1.0f;
				Vector3 pos = new Vector3(x_perturb+10, y_perturb, z_perturb+20);
				allFish_02[i] = (GameObject) Instantiate(fishPrefab_02, pos, transform.rotation);
			}
			for(int i=0; i<numFish_03; i++){
				if (allFish_03 [i].activeSelf) {
					continue;
				}
				float x_perturb = r.Next (-initTankSize, initTankSize)*1.0f;
				float y_perturb = r.Next (-tankSize_y, initTankSize)*1.0f;
				float z_perturb = r.Next (-initTankSize, initTankSize)*1.0f;
				Vector3 pos = new Vector3(x_perturb, y_perturb, z_perturb-20);
				allFish_03[i] = (GameObject) Instantiate(fishPrefab_03, pos, transform.rotation);
			}
			for(int i=0; i<numFish_04; i++){
				if (allFish_04 [i].activeSelf) {
					continue;
				}
				float x_perturb = r.Next (-initTankSize, initTankSize)*1.0f;
				float y_perturb = r.Next (-tankSize_y, initTankSize)*1.0f;
				float z_perturb = r.Next (-initTankSize, initTankSize)*1.0f;
				Vector3 pos = new Vector3(x_perturb-20, y_perturb, z_perturb);
				allFish_04[i] = (GameObject) Instantiate(fishPrefab_04, pos, transform.rotation);
			}
		}
	}
	
	// Update is called once per frame
	void Update () {

		Spawn ();
		tankSize /= 4;
		if (r.Next (0, 10000) < 50) {
			goalPos = new Vector3 (r.Next (-tankSize, tankSize), r.Next (-tankSize_y, tankSize),r.Next (-tankSize, tankSize));
		}
		if (r.Next (0, 10000) < 50) {
			goalPos_01 = new Vector3 (r.Next (-tankSize, tankSize), r.Next (-tankSize_y, tankSize),r.Next (-tankSize, tankSize));
		}
		if (r.Next (0, 10000) < 50) {
			goalPos_02 = new Vector3 (r.Next (-tankSize, tankSize), r.Next (-tankSize_y, tankSize),r.Next (-tankSize, tankSize));
		}
		if (r.Next (0, 10000) < 50) {
			goalPos_03 = new Vector3 (r.Next (-tankSize, tankSize), r.Next (-tankSize_y, tankSize),r.Next (-tankSize, tankSize));
		}
		if (r.Next (0, 10000) < 50) {
			goalPos_04 = new Vector3 (r.Next (-tankSize, tankSize), r.Next (-tankSize_y, tankSize),r.Next (-tankSize, tankSize));
		}
		tankSize *= 4;
	}
		
}