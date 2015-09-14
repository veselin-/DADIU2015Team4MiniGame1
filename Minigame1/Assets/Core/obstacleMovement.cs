using UnityEngine;
using System.Collections;

public class obstacleMovement : MonoBehaviour {

    public static float speed = 5f, scale = 1f, obstacleSpeedTime, speedTime1, speedTime2;
    public static bool spawnInLanes = true, isEnabled = true;
    public int increaseSpeedTimeInSeconds1, increaseSpeedTimeInSeconds2;


   // GameObject[] spawns;

    // Use this for initialization
    void Start () {
        increaseSpeedTimeInSeconds1 = 60;
        increaseSpeedTimeInSeconds2 = 300;
        speedTime1 = 6f;
        speedTime2 = 7f;
        gameObject.SetActive(isEnabled);
        
       // spawns = GameObject.FindGameObjectsWithTag("SpawnPoint");
    }
	
	// Update is called once per frame
	void FixedUpdate () {
        transform.localScale = new Vector3(scale, scale, scale);
        differentWavesOfObstacles();
        transform.Translate(Vector3.up * Time.deltaTime * speed);
        if (transform.position.y > 6f)
        {
            Respawn();
        }
    }

    void differentWavesOfObstacles()
    {
        obstacleSpeedTime += Time.deltaTime;
        if(obstacleSpeedTime > increaseSpeedTimeInSeconds1)
        {
            speed = speedTime1;
        }
        if (obstacleSpeedTime > increaseSpeedTimeInSeconds2)
        {
            speed = speedTime2;
        }
    }

    void Respawn()
    {
        this.gameObject.GetComponentInChildren<Collider>().enabled = true;
        this.gameObject.GetComponentInChildren<Renderer>().enabled = true;
        if (spawnInLanes)
        {
            //Random.seed = (int)(Time.deltaTime * 10000);
            transform.position = SpawnPointController.spawns[Random.Range(0, SpawnPointController.spawns.Length)].transform.position;
            Debug.Log(SpawnPointController.spawns.Length);
        }
        else
        { 
        transform.position = new Vector3(Random.Range(-3f, 3f), -5, 0);
        }
    }
}
