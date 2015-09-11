using UnityEngine;
using System.Collections;

public class VariableController : MonoBehaviour {

    public float ElephantStrafeSpeed = 5f;
    public float BackgroundScrollingSpeed = 1f;

    // Use this for initialization
    void Start () {

        BGControl.Speed = ElephantStrafeSpeed;
        BackgroundCylinderRotation.bgspeed = BackgroundScrollingSpeed;

	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
