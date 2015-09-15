using UnityEngine;
using System.Collections;
using Assets.Core;
using Assets.Core.Scripts;

public class cubeDeath : MonoBehaviour {

    public bool enableControl = true;
	public AudioManager AudioMngr;
    public GameObject heartController;

    public static bool lifeTimeHit = false;
    public static float espeed;
    public static int loseLife;



    // Use this for initialization
    void Start () {
        loseLife = 3;
		AudioMngr = GameObject.FindGameObjectWithTag ("AudioManager").GetComponent<AudioManager>();
	}
	
	// Update is called once per frame
	void Update () {
        if (enableControl) {
            if (Input.GetKey("left"))
            {
                transform.Translate(Vector3.left * Time.deltaTime * espeed);
            }
            if (Input.GetKey("right"))
            {
                transform.Translate(Vector3.right * Time.deltaTime * espeed);
            }
        }
    }

    //Restart the level when you hit an object
    void OnTriggerEnter(Collider coll)
    {
		Camera.main.GetComponent<PerlinShake> ().PlayShake ();
        loseLife -= 1;
        heartController.GetComponent<HeartController>().loseLife(loseLife);
        ScoreSystem.comboCount = 0;
        ScoreSystem.comboTimeReset();
        coll.gameObject.GetComponentInChildren<Collider>().enabled = false;
        //coll.gameObject.GetComponentInChildren<Renderer>().enabled = false;

		AudioMngr.FailPlay ();
	
        if (loseLife == 0)
        {
            if (ScoreSystem.points > PlayerPrefs.GetInt("Best score"))
            {
                PlayerPrefs.SetInt("Best score", ScoreSystem.points);
                ScoreSystem.comboCount = 0;
            }
            ScoreSystem.comboTimeReset();
            //ScoreSystem.points = 0;
            GameObject.FindGameObjectWithTag(Constants.Tags.GameMaster).GetComponent<GameOverMaster>().GameOver();
        }
        //lifeTimeHit = true;
    }
}
