using UnityEngine;
using System.Collections;

public class CloudMovement : MonoBehaviour {

    public float speed = 1f;



	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        transform.Translate(Vector3.back * Time.deltaTime * speed);

    }
}
