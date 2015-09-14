using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScoreSystem : MonoBehaviour {

    public static bool poseComplete, comboComplete, timeToCombo, poseFail;
    public Text scoreText, comboText, lifeText, lifeTimeText;
    public int pointsPose = 50, pointsFail = 25, lifes, points;

    public static int comboCount;
    public static float comboReset = 20f, comboTimeDown;
    public float startTime = 40f, timePoseComplete = 10f, timePoseFail = 5f, timeHitObstacle = 5f, timePoseCombo = 10f;

    // Use this for initialization
    void Start()
    {
        //lifes = 5;
        comboCount = 1;
        comboTimeDown = comboReset;
        scoreText.text = "Score: " + points;
        comboText.text = "Combo: x"+ comboCount;
        //lifeText.text = "Lifes: " + lifes;
        //lifeTimeText.text = "Lifetime: " + startTime;
    }

    // Update is called once per frame
    void Update()
    {
        lifeTime();
        pointSystem();
        if (timeToCombo)
        {
            comboTime();
        }
        comboText.text = "Combo: x" + comboCount;
        //lifes = cubeDeath.loseLife;
        if (cubeDeath.lifeTimeHit)
        {
            startTime -= timeHitObstacle;
            //Debug.Log("starttimebuf: " + startTimeBuf);
            //Debug.Log("hitobstaclebuf: " + hitObstacleBuf);
            cubeDeath.lifeTimeHit = false;
        }
        if (1 > startTime)
        {
            if (points > PlayerPrefs.GetInt("Best score"))
            {
                PlayerPrefs.SetInt("Best score", points);
                comboCount = 1;
            }
            comboTimeReset();
            Application.LoadLevel("gameOverScene");
        }
    }

    void pointSystem()
    {
        if (poseComplete)
        {
            if (timeToCombo && 0 < comboTimeDown)
            {
                comboCount += 1;
                points += pointsPose * comboCount;
                startTime += timePoseCombo;
                comboTimeReset();
            }
            else
            {
                points += pointsPose;
                startTime += timePoseComplete;
            }
            poseComplete = false;
            timeToCombo = true;
        }
        else if (poseFail)
        {
            points -= pointsFail;
            startTime -= timePoseFail;
            poseFail = false;
            timeToCombo = false;
            comboTimeReset();
            //lifes = lifes - 1;
            comboCount = 1;
        }
        //lifeText.text = "Lifes: " + lifes;
        scoreText.text = "Score: " + points;
    }

    void lifeTime()
    {
        startTime -= Time.deltaTime;
        lifeTimeText.text = "Lifetime: " + (int)startTime;
    }

    void comboTime()
    {
        comboTimeDown -= Time.deltaTime;
        //comboText.text = "ComboTime: " + comboTimeDown.ToString("f2");
        if (comboTimeDown < 0 || lifes != cubeDeath.loseLife)
            {
            timeToCombo = false;
            }
    }

    public static void comboTimeReset()
    {
        comboTimeDown = comboReset;
        timeToCombo = false;
    }
}
