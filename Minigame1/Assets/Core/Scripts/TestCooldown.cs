using UnityEngine;
using System.Collections;

public class TestCooldown : MonoBehaviour {

	public float timeToHold = 0.3f;
	public Animator cooldownImage;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
		if (Input.GetMouseButtonDown (0)) {
		
			if(timeToHold < 1)
			{
				cooldownImage.speed = 1f / timeToHold;
			}
			else
			{
				cooldownImage.speed = 1f * timeToHold;
			}

			Debug.Log(cooldownImage.speed);

			cooldownImage.SetBool("Active", true);
		}


		if (Input.GetMouseButtonUp (0)) {
			cooldownImage.SetBool("Active", false);
		}

	}
}
