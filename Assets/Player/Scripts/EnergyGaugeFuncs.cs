using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EnergyGaugeFuncs : MonoBehaviour
{

    public TMP_Text textEnergy;
    public float energyLeft = 999;
    public int energyLeftCount;
    //public bool energyTimerStarted = false;


    public TMP_Text textBoost;
    public float boostPower;
    public float boostPowerMax = 200;
    public bool boostHeld = false;

    public TMP_Text textTimer;
    public float timer;

    public TMP_Text textShipTracker;
    public int shipsOnStage;
    public float shipsDefeated;

    public TMP_Text textScore;
    public int score = 0;
    public GameObject finalScoreDisplay;
    public float finalScoreTotal;
    public TMP_Text textEndScore;
    public TMP_Text textEndBoost;
    public TMP_Text textEndShips;
    public TMP_Text textEndTime;
    public TMP_Text textFinalScore;

    public GameObject gameOverDisplay;
    public GameObject gameOverText1;
    public GameObject gameOverText2;
    public bool isInGameOver = false;

    // Start is called before the first frame update
    void Start()
    {
        boostPower = boostPowerMax;

    }

    public void playerInput(bool boost)
    {
        boostHeld = boost;
    }

    // Update is called once per frame
    void Update()

    {
        Energy();
        //boostRecharge();
        if(boostPower > boostPowerMax)
        {
            boostPower = boostPowerMax;
        }
        textBoost.text = ((int)boostPower).ToString();
        Timer();
        ShipTracking();
        textScore.text = score.ToString();
    }


    void Energy()
    {
        if (energyLeft > 1500)
        {
            energyLeft = 1500;
        }
        energyLeft -= Time.deltaTime;
        energyLeftCount = (int)energyLeft;
        textEnergy.text = energyLeftCount.ToString();

        if (energyLeft < 0)
        {
            energyLeft = 0;
            StartCoroutine(OutOfFuel());
        }
    }

    void boostRecharge()
    {
        textBoost.text = ((int)boostPower).ToString();
        if (!boostHeld && boostPower < boostPowerMax)
        {
            boostPower += Time.deltaTime * 10;
        }
    }

    void Timer()
    {
        timer += Time.deltaTime;

        int minutes = Mathf.FloorToInt(timer / 60F);
        int seconds = Mathf.FloorToInt(timer - minutes * 60);

        string niceTime = string.Format("{0:00}:{1:00}", minutes, seconds);


        textTimer.text = niceTime;
    }

    void ShipTracking()
    {
        shipsOnStage = GameObject.FindGameObjectsWithTag("Enemy").Length;
        textShipTracker.text = shipsOnStage.ToString();
    }

    IEnumerator OutOfFuel()
    {
        Time.timeScale = 0f;
        gameOverDisplay.SetActive(true);
        yield return new WaitForSecondsRealtime(0.5f);
        gameOverText1.SetActive(false);
        gameOverText2.SetActive(true);
        yield return new WaitForSecondsRealtime(0.5f);
        //gameOverDisplay.SetActive(false);
        gameOverText1.SetActive(false);
        gameOverText2.SetActive(false);
        yield return new WaitForSecondsRealtime(0.5f);
        finalScoreTotal = (int)(((score + boostPower) * shipsDefeated/2) * (timer))/10;
        textEndScore.text = score.ToString();
        boostPower = (int)boostPower;
        textEndBoost.text = boostPower.ToString();
        textEndShips.text = shipsDefeated.ToString();
        timer = (int)timer;
        textEndTime.text = timer.ToString();
        textFinalScore.text = finalScoreTotal.ToString();
        finalScoreDisplay.SetActive(true);
        isInGameOver = true;
        yield return null;
    }

}
