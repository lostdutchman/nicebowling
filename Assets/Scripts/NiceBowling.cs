﻿using UnityEngine;
using System.Collections;

public class NiceBowling : MonoBehaviour {
	
	public bool timeForNice = false;
	public GameObject Bumper, Bumper2;
	public GameObject Cylinder, Sardine, Ramp;
	private float gravityX, gravityY, gravityZ;
	private GameObject light;
	public Material ball1, ball2, ball3, SkySpace, SkyUnity, SkyHorror; //Absolutly get gid of cosmetic changes that are not tied to gameplay changes and kill the horrer concept.
	public PhysicMaterial Bounce, none;
	public GameObject dumbPinSet;
	private Camera MainCamera;
	private float volume;
	

	// Use this for initialization
	void Start () {
		//This initializes the player pref incase its the first time playing and they didnt go to the options page
		if (!PlayerPrefs.HasKey ("nice_bowling"))
			PlayerPrefsManager.NiceBowlingSet(1);
		gravityX = 0;
		gravityY = -150;
		gravityZ = 0;
		light = GameObject.Find ("Directional Light");
		volume = PlayerPrefsManager.GetMasterVolume();
        MainCamera = Camera.main;
    }

	//use for initilization if level is loaded more then onece in a session
	void OnLevelWasLoaded(){
		gravityX = 0;
		gravityY = -150;
		gravityZ = 0;
		Physics.gravity= new Vector3(gravityX, gravityY, gravityZ);
		volume = PlayerPrefsManager.GetMasterVolume();
		MusicManager musicManager = GameObject.FindObjectOfType<MusicManager>();
		musicManager.ChangeVolume (volume);
	}

	public void Effect() {
		if(PlayerPrefsManager.NiceBowlingGet() == 1){
		int niceRandom = Random.Range(1, 50);
		switch(niceRandom){
			case 1:NoGravityAllPins(); break;
			case 2:CarnyPins(); break; 
			case 3:GravityX(); break;
			case 4:GravityYHeavy(); break;
			case 5:GravityDiff(); break;
			case 6:GravityYLight(); break;
			case 7:IncreasePinDrag(); break; 
			case 8: Effect(); break;
            case 9:IncreasePinSize(); break;
			case 10:DecreasePinSize(); break;
			case 11: Effect(); break;
            case 12:BouncyBall(); break;
			case 13: Effect(); break;
            case 14: Effect(); break;
            case 15: Effect(); break;
            case 16:GiantBall (); break;
			case 17:SmallBall (); break;
			case 18:Cheater(); break;
			case 19: Effect(); break;
            case 20:TinyBall(); break;
			case 21:LargeBall(); break;
			case 22:LightBall (); break;
			case 23:HeavyBall (); break;
			case 24: Effect(); break;
            case 25: Effect(); break;
            case 26: Effect(); break;
            case 27:CarnyPin(); break;
			case 28: Effect(); break;
            case 29:Bumpers (); break;
			case 30: Effect(); break;
            case 31:SardineRain (); break;
			case 32:Obstical (); break;
			case 33:Obsticals(); break;
			case 34:RampAdd(); break;
			case 35: Effect(); break;
            case 36: Effect(); break;
            case 37: Effect(); break;
            case 38: Effect(); break;
            case 39:AddPinsx1(); AddPinsx4(); break;
			case 40:AddPinsx1(); break;
			case 41: Effect(); break;
            case 42: Effect(); break;
            case 43:AddPinsx4(); break;
			case 44: Effect();  break;
            case 45: Effect(); Effect(); break;
			case 46:Effect(); Effect(); break;
			case 47:Effect(); Effect(); break;
			case 48:Effect(); Effect(); Effect(); break;
			case 49:Effect(); Effect(); Effect(); break;
			case 50:Effect(); Effect(); Effect(); Effect(); break;
			
			default:print ("NiceBowling.Effect switch case default triggered somehow"); break;
			}
		}
	}
	//Each switch case will call a function below
	
	//Case1
	public void NoGravityAllPins(){
		foreach(Pins pin in GameObject.FindObjectsOfType<Pins>()){
			Rigidbody body = pin.GetComponent<Rigidbody>();
			body.useGravity = false;
		}
	}
	
	//Case2
	public void CarnyPins(){
		foreach(Pins pin in GameObject.FindObjectsOfType<Pins>()){
			Rigidbody body = pin.GetComponent<Rigidbody>();
			body.isKinematic = true;
		}
	}

    //Case3 gravity flux (x) + or - whole lane (Wind on x axis)
    public void GravityX(){
		gravityX = Random.Range (-10, 10);
		Physics.gravity= new Vector3(gravityX, gravityY, gravityZ);
	}

	//Case4 gravity flux (y) Heavy side only 
	public void GravityYHeavy(){
		gravityY = Random.Range (-600, -200);
		Physics.gravity= new Vector3(gravityX, gravityY, gravityZ);
	}

	//Case5 gravity flux (z) + or - whole lane (Wind on Z axis)
	public void GravityDiff(){
		gravityY = Random.Range (-400, 3);
		Physics.gravity= new Vector3(gravityX, gravityY, gravityZ);
		foreach(Pins pin in GameObject.FindObjectsOfType<Pins>()){
			int number = Random.Range (1, 4);
			if(number == 2){
			Rigidbody body = pin.GetComponent<Rigidbody>();
			body.useGravity = false;
			}
		}
		
		Physics.gravity= new Vector3(gravityX, gravityY, gravityZ);
	}

	//Case6 gravity flux (y) light side only
	public void GravityYLight(){
		gravityY = Random.Range (-150, 3);
		Physics.gravity= new Vector3(gravityX, gravityY, gravityZ);
	}

	//Case7 
	public void IncreasePinDrag(){
		foreach(Pins pin in GameObject.FindObjectsOfType<Pins>()){
			Rigidbody body = pin.GetComponent<Rigidbody>();
			body.angularDrag = Random.Range (0.05f, 50f);
			body.drag = Random.Range (0, 20);
		}
	}
	
	//Case8 

	//Case9
	public void IncreasePinSize(){
		float size = Random.Range (1.2f, 2.5f);
		foreach(Pins pin in GameObject.FindObjectsOfType<Pins>()){
			pin.transform.localScale = new Vector3(size, size, size);
		}
	}
	//Case10
	public void DecreasePinSize(){
		float size = Random.Range (0.6f, 0.95f);
		foreach(Pins pin in GameObject.FindObjectsOfType<Pins>()){
			pin.transform.localScale = new Vector3(size, size, size);
		}
	}
	//Case11

	//Case12
	public void BouncyBall(){
		Ball ball = GameObject.FindObjectOfType<Ball>();
		SphereCollider col = ball.GetComponent<SphereCollider>();
		col.sharedMaterial = Bounce;
		
	}
	
	//Case13

	//Case14

	//Case15

	//Case16 
	public void GiantBall(){
	Ball ball = GameObject.FindObjectOfType<Ball>();
	ball.transform.localScale = new Vector3 (40f, 40f, 40f);
	}
	
	//Case17 
	public void SmallBall(){
		Ball ball = GameObject.FindObjectOfType<Ball>();
		ball.transform.localScale = new Vector3 (10f, 10f, 10f);
	}
	//Case18
	public void Cheater(){
		Ball ball = GameObject.FindObjectOfType<Ball>();
		ball.transform.localPosition += new Vector3(0, 0, 1000f);
	}
	//Case19

	//Case20 
	public void TinyBall(){
		Ball ball = GameObject.FindObjectOfType<Ball>();
		ball.transform.localScale = new Vector3 (5f, 5f, 5f);
	}
	//Case21 
	public void LargeBall(){
		Ball ball = GameObject.FindObjectOfType<Ball>();
		ball.transform.localScale = new Vector3 (30f, 30f, 30f);
	}
	//Case22 
	public void LightBall(){
		Ball ball = GameObject.FindObjectOfType<Ball>();
		Rigidbody body = ball.GetComponent<Rigidbody>();
		Renderer rend = ball.GetComponent<Renderer> ();
		rend.material = ball2;
		body.mass = .5f;
	}
	//Case23 
	public void HeavyBall(){
		Ball ball = GameObject.FindObjectOfType<Ball>();
		Rigidbody body = ball.GetComponent<Rigidbody>();
		Renderer rend = ball.GetComponent<Renderer> ();
		rend.material = ball3;
		body.mass = 70;
	}
	//Case24

	//Case27
	public void CarnyPin(){
		foreach(Pins pin in GameObject.FindObjectsOfType<Pins>()){
			int number = Random.Range (1, 9);
			if(number == 8){
				Rigidbody body = pin.GetComponent<Rigidbody>();
				body.isKinematic = true;
				}
		}
	}
	
	//Case28
	
	//Case29 
	public void Bumpers(){
		Bumper.SetActive(true);
		Bumper2.SetActive(true);
	}
	//Case30 

	//Case31 
	public void SardineRain(){
		int rand = Random.Range (10, 200);
		for(int i = 0; i < rand; i++){
			Instantiate(Sardine, new Vector3(Random.Range (55f, -55f), Random.Range (50f, 200f), Random.Range (150f, 2000f)), Quaternion.Euler (Random.Range (0f, 360f), Random.Range (0f, 360f), Random.Range (0f, 360f)));
			}
	}
	//Case32 
	public void Obstical(){
		Instantiate(Cylinder, new Vector3(Random.Range (55f, -55f), Random.Range (40f, -30f), Random.Range (300f, 1600f)), Quaternion.identity);
	}
	//Case33 
	public void Obsticals(){
		float z = Random.Range (400f, 1600f);
		float y = Random.Range (30f, -10f);
		Instantiate(Cylinder, new Vector3(40f, y, z), Quaternion.identity);
		Instantiate(Cylinder, new Vector3(-40f, y, z), Quaternion.identity);
	}
	//Case34 
	public void RampAdd(){
		Instantiate(Ramp, new Vector3(0, -3, Random.Range (300f, 1600f)), Quaternion.Euler (-10, 0, 0));
	}
	//Case35

	//Case36 

	//Case37 
	
	//Case38 Global Reset
	
	//Case39 Add all the pins
	
	//Case40 add dummy pins X1
	public void AddPinsx1(){
		Instantiate(dumbPinSet, new Vector3(0, 1, 1285), Quaternion.identity);
	}
	//Case41

	//Case42

	//Case43
	public void AddPinsx4(){
		Instantiate(dumbPinSet, new Vector3(0, 1, 1495), Quaternion.identity);
		Instantiate(dumbPinSet, new Vector3(0, 1, 1530), Quaternion.identity);
		Instantiate(dumbPinSet, new Vector3(0, 1, 1565), Quaternion.identity);
		Instantiate(dumbPinSet, new Vector3(0, 1, 1600), Quaternion.identity);
	}
	//Case44 - 45

	//Cases 46-50 call effect multiple times
	
}

