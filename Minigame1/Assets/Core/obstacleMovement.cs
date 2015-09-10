using UnityEngine;
using System.Collections;

public class obstacleMovement : MonoBehaviour {

    public float speed = 5f;

    public bool spawnInLanes = true;

    GameObject[] spawns;

	// Use this for initialization
	void Start () {

        spawns = GameObject.FindGameObjectsWithTag ("SpawnPoint");

	}
	
	// Update is called once per frame
	void FixedUpdate () {

        transform.Translate(Vector3.up * Time.deltaTime * speed);

        if (transform.position.y > 5f)
        {
            Respawn();
        }


    }


    void Respawn()
    {

        if (spawnInLanes)
        {

            transform.position = spawns[Random.Range(0, spawns.Length)].transform.position;

        }
        else { 
        transform.position = new Vector3(Random.Range(-3f, 3f), -5, 0);
        }
    }

}
