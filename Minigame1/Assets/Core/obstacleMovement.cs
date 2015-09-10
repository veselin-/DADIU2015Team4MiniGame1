using UnityEngine;
using System.Collections;

public class obstacleMovement : MonoBehaviour {

    public float speed = 5f;

    public bool control = true;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        transform.Translate(Vector3.up * Time.deltaTime * speed);

        if (transform.position.y > 5f)
        {
            Respawn();
        }

        if (control) { 

        if (Input.GetKey("right"))
        {
            transform.Translate(Vector3.left * Time.deltaTime * speed);
        }

        if (Input.GetKey("left"))
        {
            transform.Translate(Vector3.right * Time.deltaTime * speed);
        }


}


    }


    void Respawn()
    {

        transform.position = new Vector3(Random.Range(-3f, 3f), -5, 0);

    }

}
