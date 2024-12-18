﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BilliardBall : MonoBehaviour {

    private Rigidbody rigidBody;
    [Tooltip("How much force is multipied on impact with ball.")]
    public float ForceToAdd = 4;
    [Tooltip("How long in seconds the camera follows the billiard ball.")]
    public float TimeToFollow = 1.2f;
    public Camera MainCamera;
    private AudioSource ClackNoise;

    private void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
        MainCamera = Camera.main;
        ClackNoise = GetComponent<AudioSource>();
    }

    private void OnCollisionEnter(Collision col)
    {
        if(col.gameObject.tag == "ChildBall")
        {
            Vector3 HitForce = (transform.position - col.contacts[0].point).normalized * ForceToAdd;
            rigidBody.AddForce(HitForce, ForceMode.Impulse);
            MainCamera.GetComponent<CameraControl>().BilliardHit(this.gameObject, TimeToFollow);
        }
        ClackNoise.Play();
    }
}
