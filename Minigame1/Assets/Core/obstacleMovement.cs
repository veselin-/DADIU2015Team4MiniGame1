﻿using UnityEngine;
using System.Collections;

public class obstacleMovement : MonoBehaviour {

    public static float speed = 5f, scale = 1f, obstacleSpeedTime;
    public static bool spawnInLanes = true, isEnabled = true;
    public int secondsAfterEachIncrease = 30;
    private float theIntervalOfSpeedBoost = 0.1f, maxSpeed = 6f;

    private bool _isGameOver;


   // GameObject[] spawns;

    // Use this for initialization
    void Start () {
        gameObject.SetActive(isEnabled);
        speed = 5f;
       // spawns = GameObject.FindGameObjectsWithTag("SpawnPoint");
    }
	
	// Update is called once per frame
	void Update () {
        if (_isGameOver) return;

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
        if(obstacleSpeedTime > secondsAfterEachIncrease)
        {
            if (speed > maxSpeed)
            {
                speed = maxSpeed;
            }
            else
            {
                secondsAfterEachIncrease += 30;
                speed += theIntervalOfSpeedBoost;
                Debug.Log("DET HER ER HASTIGHEDEN NU" + speed);
            }
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

    public void StopSpawning()
    {
        _isGameOver = true;
    }
}
