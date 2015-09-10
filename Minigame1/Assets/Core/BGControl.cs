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

    void OnMouseDrag()
    {

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit = new RaycastHit();


        if (Physics.Raycast(ray, out hit, 100, 8))
        {



        }
            

        Debug.Log(Input.mousePosition);

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
