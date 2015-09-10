using UnityEngine;
using System.Collections;

public class BGControl : MonoBehaviour {

    public GameObject Elephant;

    public float speed = 5f;

    float destination = 0f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {

        if (destination >= Elephant.transform.position.x)
        {

            Elephant.transform.Translate(Vector3.right * Time.deltaTime * speed);

        }

        if (destination < Elephant.transform.position.x)
        {

            Elephant.transform.Translate(Vector3.left * Time.deltaTime * speed);

        }


    }

    void OnMouseDown()
    {

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit = new RaycastHit();


        if (Physics.Raycast(ray, out hit, 100))
        {

            destination = hit.point.x;

        }
            
    }

}
