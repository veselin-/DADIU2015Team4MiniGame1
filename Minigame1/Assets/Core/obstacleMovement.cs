using UnityEngine;
using System.Collections;

public class obstacleMovement : MonoBehaviour {

    public static float speed = 5f;

    public static bool spawnInLanes = true;

    public static float scale = 1f;

    public static bool isEnabled = true;

    GameObject[] spawns;

	// Use this for initialization
	void Start () {
        gameObject.SetActive(isEnabled);
        spawns = GameObject.FindGameObjectsWithTag("SpawnPoint");
    }
	
	// Update is called once per frame
	void FixedUpdate () {
        transform.localScale = new Vector3(scale, scale, scale);
        transform.Translate(Vector3.up * Time.deltaTime * speed);
        if (transform.position.y > 5f)
        {
            Respawn();
        }
    }


    void Respawn()
    {
        this.gameObject.GetComponentInChildren<Collider>().enabled = true;
        this.gameObject.GetComponentInChildren<Renderer>().enabled = true;
        if (spawnInLanes)
        {
            transform.position = spawns[Random.Range(0, spawns.Length)].transform.position;
           }
        else
        { 
        transform.position = new Vector3(Random.Range(-3f, 3f), -5, 0);
        }
    }
}
