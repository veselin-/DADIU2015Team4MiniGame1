using UnityEngine;
using System.Collections;

public class cubeDeath : MonoBehaviour {

    public bool control = true;

    public float speed = 5f;

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (control) {
            if (Input.GetKey("left"))
            {
                transform.Translate(Vector3.left * Time.deltaTime * speed);
            }

            if (Input.GetKey("right"))
            {
                transform.Translate(Vector3.right * Time.deltaTime * speed);
            }
        }

        if (Input.GetButtonDown("Fire1"))
        {
           
        }


    }

    void OnTriggerEnter(Collider coll)
    {
       // Debug.Log("HIT");
        Application.LoadLevel(Application.loadedLevel);

    }

   

}
