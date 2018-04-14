﻿using UnityEngine;
using UnityEngine.SceneManagement;

public class OpeningBall : MonoBehaviour {

	private Rigidbody rigidBody;
	public AudioSource canvas;
	public float launchSpeed;
	private GameObject menu;
	private float MenuTimeDelay;
	public AudioClip[] niceBowling;
    private GameObject Splash;

	// Use this for initialization
	void Start () {
		rigidBody = GetComponent<Rigidbody>();
		menu = GameObject.Find ("Canvas");
		menu.SetActive (false);
		float yPos = rigidBody.transform.position.y;
		float zPos = rigidBody.transform.position.z;
		rigidBody.transform.position = new Vector3 (Random.Range(-10, 10), yPos, zPos);
		ThrowBall ();
	    canvas.clip = niceBowling[Random.Range(0, niceBowling.Length)];
        MenuTimeDelay = GameObject.FindObjectOfType<MusicManager>().MenuTimeDelay + .5f; //.5f for the splash screen fade time
        Splash = GameObject.FindObjectOfType<PanelFade>().gameObject;

    }

    // Update is called once per frame
    void Update () {
		if(Time.timeSinceLevelLoad >= MenuTimeDelay){
			menu.SetActive(true);
            Splash.SetActive(false);
		}
	}
	
	public void ThrowBall ()
	{
		rigidBody.useGravity = true;
		rigidBody.velocity = new Vector3 (0, 0, launchSpeed);
		rigidBody.angularVelocity = new Vector3 (20, 0, 0);
	}
}
