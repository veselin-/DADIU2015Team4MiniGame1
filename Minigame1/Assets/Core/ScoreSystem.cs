using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScoreSystem : MonoBehaviour {

    public static bool poseComplete, comboComplete, timeToCombo, poseFail;
    public Text scoreText, comboText, lifeText, lifeTimeText;
    public int pointsPose = 50, pointsFail = 25, lifes;

    public static int comboCount, points;
    public static float comboReset = 7f, comboTimeDown;
    //public float startTime = 40f, timePoseComplete = 10f, timePoseFail = 5f, timeHitObstacle = 5f, timePoseCombo = 10f;

    public GameObject star, hearts, pointText;

    // Use this for initialization
    void Start()
    {
        lifes = 3;
        comboCount = 0;
        comboTimeDown = comboReset;
        scoreText.text = points.ToString();
        comboText.text = "x"+ comboCount;
        //lifeText.text = "Lives: " + lifes;
        star.SetActive(false);
        //lifeTimeText.text = "Lifetime: " + startTime;
    }

    // Update is called once per frame
    void Update()
    {
        
        //lifeTime();
        if (comboCount == 0)
        {
            star.SetActive(false);
        }
        pointSystem();
        if (timeToCombo)
        {
            comboTime();
        }
        comboText.text = "x" + comboCount;
        lifes = cubeDeath.loseLife;

        //if (cubeDeath.lifeTimeHit)
        //{
        //    startTime -= timeHitObstacle;
        //    //Debug.Log("starttimebuf: " + startTimeBuf);
        //    //Debug.Log("hitobstaclebuf: " + hitObstacleBuf);
        //    cubeDeath.lifeTimeHit = false;
        //}
        //if (1 > startTime)
        //{
        //    if (points > PlayerPrefs.GetInt("Best score"))
        //    {
        //        PlayerPrefs.SetInt("Best score", points);
        //        comboCount = 1;
        //    }
        //    comboTimeReset();
        //    Application.LoadLevel("gameOverScene");
        //}
    }

    void pointSystem()
    {
        if (poseComplete)
        {

            star.SetActive(true);

            if (timeToCombo && 0 < comboTimeDown)
            {
                comboCount += 1;
                points += pointsPose * comboCount;
                pointText.GetComponent<pointTextController>().showPoints(pointsPose * comboCount);
                //startTime += timePoseCombo;
                comboTimeReset();
            }
            else
            {
                comboCount = 2;
                points += pointsPose;
                pointText.GetComponent<pointTextController>().showPoints(pointsPose);
                //startTime += timePoseComplete;
            }

            animateStar();
            poseComplete = false;
            timeToCombo = true;
            
        }
        else if (poseFail)
        {
            points -= pointsFail;
            //startTime -= timePoseFail;
            poseFail = false;
            timeToCombo = false;
            comboTimeReset();
            lifes = lifes - 1;
            comboCount = 0;
        }
        if (0 > comboTimeDown)
        {
            comboCount = 0;
            comboText.text = "x" + comboCount;
            comboTimeReset();
        }
        if (lifes < 0)
        {
            lifes = 0;
        }

//        lifeText.text = "Lives: " + lifes;
        scoreText.text = points.ToString();
        hearts.GetComponent<HeartController>().lives = lifes;

    }

    //void lifeTime()
    //{
    //    startTime -= Time.deltaTime;
    //    lifeTimeText.text = "Lifetime: " + (int)startTime;
    //}

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

    void animateStar()
    {
        star.GetComponent<Animation>().Play();
        Debug.Log("Animated Star");
    }
}
