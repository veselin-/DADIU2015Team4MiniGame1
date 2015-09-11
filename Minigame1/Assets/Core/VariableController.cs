using UnityEngine;
using System.Collections;

public class VariableController : MonoBehaviour {

    public float ElephantStrafeSpeed = 5f;
    public float BackgroundScrollingSpeed = 1f;

    public float ObstacleScale = 1f;
    public float ObstacleSpeed = 1f;
    public bool UseLanes = true;

    public float ObstacleDistance = 2f;

    // Use this for initialization
    void Awake () {

        BGControl.Speed = ElephantStrafeSpeed;
        BackgroundCylinderRotation.bgspeed = BackgroundScrollingSpeed;
        SpawnPointController.distance = ObstacleDistance;
        obstacleMovement.speed = ObstacleSpeed;
        obstacleMovement.spawnInLanes = UseLanes;
        obstacleMovement.scale = ObstacleScale;

	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
