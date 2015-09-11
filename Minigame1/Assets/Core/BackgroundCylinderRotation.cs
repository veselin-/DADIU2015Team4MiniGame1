using UnityEngine;
using System.Collections;

public class BackgroundCylinderRotation : MonoBehaviour {

    public static float bgspeed;

    // Use this for initialization
    void Start () {

     

}
	
	// Update is called once per frame
	void Update () {

        transform.Rotate(Vector3.down * Time.deltaTime * bgspeed);


    }
}
