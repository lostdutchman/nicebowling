﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PinSetter : MonoBehaviour {
	
	public GameObject pinSet;
	public AudioClip[] strikeAudio;
	public AudioClip[] spareAudio;
	public AudioClip[] turkeyAudio;
	public AudioClip[] gutterAudio;
	public AudioClip silence;
	public GameObject exitButton, Swipper, TouchInput, Tut;
	public bool GameOver;

	private AudioSource audioSource;
	private NiceBowling niceBowling;
	private Animator animator;
	private PinCounter pinCounter;
	
	
	void Start () {
		GameOver = false;
		animator = GetComponent<Animator>();
		pinCounter = GameObject.FindObjectOfType<PinCounter> ();
		audioSource = GetComponent <AudioSource> ();
		niceBowling = GameObject.FindObjectOfType<NiceBowling> ();

		Swipper.SetActive (false);
		exitButton.SetActive(false);
		Tut.SetActive (true);

	}

	//Called by animator to rais pins
	public void RaisePins(){
		if (PlayerPrefsManager.NiceBowlingGet () == 1) {
			foreach (Pins pin in GameObject.FindObjectsOfType<Pins>()) {
				pin.DefaultPins ();//If nice bowling is active then fix pin settings before instantiating new ones.
			}
		}
		foreach(Pins pin in GameObject.FindObjectsOfType<Pins>()){
			pin.Raise();
		}
	}
	
	//Called by animator to lowwer pins
	public void LowerPins(){
		foreach(Pins pin in GameObject.FindObjectsOfType<Pins>()){
			pin.Lower();
			Swipper.SetActive (false);
		}
	}
	
	//Called by animator to add a new set of pins
	public void RenewPins(){
		Instantiate(pinSet, new Vector3(0, 1, 1829), Quaternion.identity);
		Swipper.SetActive (false);
		niceBowling.Effect ();
			
	}

	public void performAction(ActionMaster.Action action){
		//Pass pins that have fallen to Action Master to initiate animations
		switch(action){
		case ActionMaster.Action.Tidy:		animator.SetTrigger("tidyTrigger"); Swipper.SetActive (true); TouchInput.SetActive (false); Tut.SetActive (false);break;
		case ActionMaster.Action.Reset:		animator.SetTrigger("resetTrigger"); pinCounter.Reset(); Swipper.SetActive (true); TouchInput.SetActive (false); Tut.SetActive (false); break;
		case ActionMaster.Action.EndTurn:	animator.SetTrigger("resetTrigger"); pinCounter.Reset(); Swipper.SetActive (true); TouchInput.SetActive (false); break;
		case ActionMaster.Action.EndGame:	GameEndButton (); break;
		default: Debug.Log ("Pinsetter.PinsHaveSettled recived invalid input from ActionMaster"); break;
		}
	}

	void OnTriggerEnter(Collider collider){
		GameObject gameObject = collider.gameObject;
		
		if(gameObject.GetComponent<Ball>())
			BallOutOfPlay.ballout = true;
	}

	public void PlayAudio(int type){
		switch (type){
		case 1: audioSource.clip = strikeAudio[Random.Range(0, strikeAudio.Length)]; break;
		case 2: audioSource.clip = spareAudio[Random.Range(0, spareAudio.Length)]; break;
		case 3: audioSource.clip = turkeyAudio[Random.Range(0, turkeyAudio.Length)]; break;
		case 4: audioSource.clip = gutterAudio[Random.Range(0, gutterAudio.Length)]; break;
		case 5: audioSource.clip = silence; break;
			default: break;
		}

		audioSource.Play();

	}
	
	public void GameEndButton(){
		exitButton.SetActive(true);
		TouchInput.SetActive (false);
		GameOver = true;

	}
	
	public void EnableTouch(){
		TouchInput.SetActive (true);
	}

}
