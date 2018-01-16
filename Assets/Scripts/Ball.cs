﻿using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour {

	private Rigidbody rigidBody;
	public bool inPlay = false;
	private Vector3 ballStartPos;
	private AudioSource audioSource;
	
	void Start () {
		rigidBody = GetComponent<Rigidbody>();
		rigidBody.useGravity = false;
		audioSource = GetComponent<AudioSource> ();
    }

    public void Launch (Vector3 velocity)
	{
		ballStartPos = this.transform.position;
		rigidBody.useGravity = true;
		rigidBody.velocity = velocity;
		inPlay = true;
		audioSource.Play();
	}
	
	public void Reset ()
	{
		this.transform.position = ballStartPos;
		this.transform.rotation = Quaternion.identity;
		rigidBody.useGravity = false;
		rigidBody.velocity = Vector3.zero;
		rigidBody.angularVelocity = Vector3.zero;
		inPlay = false;
	}

    void FixedUpdate()
    {
        //Make it so that if ball stops moving the frame resets
        if (inPlay)
        {
            if (rigidBody.velocity.z <= 0)
            {
                BallOutOfPlay.ballout = true;
            }
        }
    }
}
