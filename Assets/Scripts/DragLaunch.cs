﻿using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Ball))]
public class DragLaunch : MonoBehaviour {

	private Ball ball;
	private Vector3 startPos, endPos;
	private float startTime, endTime;
	private const float ballReleseHight = 0;
	private const float minLaunchSpeed = 40;
    [Tooltip("How fast the aim arrows should move the ball.")]
    public float aimAdjust = 3;
    private bool rightAim = false;
    private bool leftAim = false;
    [Tooltip("1 = no handicap 1.6 = old handicap")]
    public float MakeAimEasier = 1.2f;
    [Tooltip("1 = no handicap Higher numbers slow bowl speeds")]
    public float SlowDown = 1;

    void Start () {
		ball = GetComponent<Ball>();
	}

    //Allow user to hold to continuasly adjust aim
    private void Update()
    {
        if (rightAim || leftAim)
        {
            if (!ball.inPlay)
            {
                float aimAdjustDirection = aimAdjust;
                if (leftAim)
                {
                    aimAdjustDirection = aimAdjust * -1;
                }
                float xPos = Mathf.Clamp(ball.transform.position.x + aimAdjustDirection, -50f, 50f);
                float yPos = ball.transform.position.y;
                float zPos = ball.transform.position.z;
                ball.transform.position = new Vector3(xPos, yPos, zPos);
            }
        }
    }

    public void onPointerDownAdjust(string direction)
    {
        if (direction.ToLower() == "right") { rightAim = true; }
        else if (direction.ToLower() == "left") { leftAim = true; }
    }

    public void OnPointerUpAdjust()
    {
        rightAim = false;
        leftAim = false;
    }

    //Figures out where you started dragging to launch the ball
    public void DragStart(){
	startPos = Input.mousePosition;
	startTime = Time.time;
	}
	
	//Figures out where you stopped dragging to launch the ball
	public void DragEnd(){
	endPos = Input.mousePosition;
	endTime = Time.time;
	CalculateDrag ();
	}
	
	//Calculates the direction and speed of the ball launch using info from the previous 2 methods.
	public void CalculateDrag(){
		if(!ball.inPlay){
			float dragDuration = endTime - startTime;
			//Speed = distance (end - start) devided by time
			float launchSpeedX = (endPos.x - startPos.x) / MakeAimEasier; //I devided it by 1.2 to keep it easier to bowl straight.
			float launchSpeedZ = ((endPos.y - startPos.y) / dragDuration) / SlowDown;

            //Makes sure player bowled properly
            if (launchSpeedZ < minLaunchSpeed){
                ball.TryAgain();
			} else {
			ball.Launch (new Vector3(launchSpeedX, ballReleseHight, launchSpeedZ));
			}
		}
	}
}
