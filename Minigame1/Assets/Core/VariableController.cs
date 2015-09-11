﻿using UnityEngine;
using System.Collections;

public class VariableController : MonoBehaviour {

    public float ElephantStrafeSpeed = 5f;
    public float BackgroundScrollingSpeed = 1f;
    public float ForegroundScrollingSpeed = 1f;

    public float ObstacleScale = 1f;
    public float ObstacleSpeed = 1f;
    public bool UseLanes = true;

    public float LaneWidth = 2f;
    public bool ObstacleIsEnabled = true;


    // Use this for initialization
    void Awake () {

        BGControl.Speed = ElephantStrafeSpeed;
        BackgroundCylinderRotation.bgspeed = BackgroundScrollingSpeed;
        ForegroundCylinderRotation.fgspeed = ForegroundScrollingSpeed;
        SpawnPointController.distance = LaneWidth;
        obstacleMovement.speed = ObstacleSpeed;
        obstacleMovement.spawnInLanes = UseLanes;
        obstacleMovement.scale = ObstacleScale;
        obstacleMovement.isEnabled = ObstacleIsEnabled;

	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
