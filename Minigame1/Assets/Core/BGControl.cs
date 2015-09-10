using UnityEngine;
using System.Collections;

public class BGControl : MonoBehaviour {

    public GameObject Elephant;

    public float speed = 5f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

	
	}

    void OnMouseDown()
    {

        if (Input.mousePosition.x >= Elephant.transform.position.x)
        {

            Elephant.transform.Translate(Vector3.right * Time.deltaTime * speed);

        }

        if (Input.mousePosition.x < Elephant.transform.position.x)
        {

            Elephant.transform.Translate(Vector3.left * Time.deltaTime * speed);

        }

    }

}
