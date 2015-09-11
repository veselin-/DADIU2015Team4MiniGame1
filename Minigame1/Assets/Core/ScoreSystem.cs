using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScoreSystem : MonoBehaviour {

    public static bool poseComplete, comboComplete, timeToCombo, poseFail;
    public Text scoreText, comboText, lifeText;
    public int pointsPose = 50, pointsFail = 25, lifes;
    int points = 0, comboCount;
    public float comboReset = 20f;
    float comboTimeDown;

    // Use this for initialization
    void Start()
    {
        //lifes = 5;
        comboCount = 1;
        comboTimeDown = comboReset;
        scoreText.text = "Score: " + points;
        comboText.text = "ComboTime: No combo";
        lifeText.text = "Lifes: " + lifes;
    }

    // Update is called once per frame
    void Update()
    {
        pointSystem();
        if (timeToCombo)
        {
            comboTime();
        }
        lifes = cubeDeath.loseLife;
    }

    void pointSystem()
    {
        if (poseComplete)
        {
            if (timeToCombo && 0 < comboTimeDown)
            {
                comboCount += 1;
                points += pointsPose * comboCount;
                comboTimeDown = comboReset;
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
            comboTimeDown = comboReset;
            //lifes = lifes - 1;
            comboCount = 1;
        }
        lifeText.text = "Lifes: " + lifes;
        scoreText.text = "Score: " + points;
    }

    void comboTime()
    {
        comboTimeDown -= Time.deltaTime;
        comboText.text = "ComboTime: " + comboTimeDown.ToString("f2");
        if (comboTimeDown < 0)
            {
            comboText.text = "ComboTime: No combo";
            timeToCombo = false;
            }
    }
}
