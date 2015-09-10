using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScoreSystem : MonoBehaviour {

    public static bool poseComplete, comboComplete, timeToCombo, poseFail;
    public Text scoreText, comboText, lifeText;
    public int points = 0, pointsPose = 50, pointsFail = 25, comboCount, lifes;
    public float combo = 0, comboTimeDown = 5.0f;

    // Use this for initialization
    void Start () {
        lifes = 5;
        comboCount = 1;
        scoreText.text = "Score: " + points;
        comboText.text = "ComboTime: " + combo;
        lifeText.text = "Lifes: " + lifes;
    }

    // Update is called once per frame
    void Update() {
        pointSystem();
        if (timeToCombo)
        {
            comboTime();
        }
    }

    void pointSystem()
    {
        if (poseComplete)
        {
            if (timeToCombo && combo < comboTimeDown)
            {
                Debug.Log("combocount" + comboCount);
                comboCount += 1;
                points += pointsPose * comboCount;
                combo = 0;
            }
            else
            {
            points += pointsPose;
            }
        poseComplete = false;
        timeToCombo = true;    
        }
        else if (poseFail)
        {
            points -= pointsFail;
            poseFail = false;
            timeToCombo = false;
            combo = 0;
            lifes = lifes - 1;
            comboCount = 1;
        }
        comboText.text = "ComboTime: " + combo;
        lifeText.text = "Lifes: " + lifes;
        scoreText.text = "Score: " + points;
    }

    void comboTime()
    {
        combo += Time.deltaTime;
            if (combo >= comboTimeDown)
            {
                combo = 0;
                timeToCombo = false;
            } 
        comboText.text = "ComboTime: " + combo;
    }
}
