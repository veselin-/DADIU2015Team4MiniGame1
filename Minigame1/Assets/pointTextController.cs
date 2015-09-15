using UnityEngine;
using System.Collections;

public class pointTextController : MonoBehaviour {

    Transform elephant;

	// Use this for initialization
	void Start () {

        elephant = GameObject.Find("Elephant").transform;

	}
	
	// Update is called once per frame
	void Update () {

        GetComponent<Renderer>().enabled = GetComponent<Animation>().IsPlaying("pointFlyUp");
	
	}

    public void showPoints(int points)
    {

        GetComponent<TextMesh>().text = points.ToString();
        transform.position = elephant.position;
        GetComponent<Animation>().Play();

    }
}
