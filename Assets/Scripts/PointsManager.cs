using TMPro;
using System;
using UnityEngine;

public class PointsManager : MonoBehaviour
{
    public int playerMaxEnergy;
    public int actualPlayerEnergy;
    public int bossMaxEnergy;
    public int actualBossEnergy;
    public int gamePoints;

    public string gamePointsString;
    public bool alive;

    //public LifebarManager healthBar;
    public TMP_Text pointsDisplay;
    //public GameObject gameOverPanel;

    void Start()
    {
        //gameOverPanel.SetActive(false);
        bossMaxEnergy = 200;
        playerMaxEnergy = 100;
        gamePoints = 0;
        alive = true;

        actualPlayerEnergy = playerMaxEnergy;
        actualBossEnergy = bossMaxEnergy;
        //healthBar.SetMaxHealth(actualPlayerEnergy);
        
        pointsDisplay.text = "0";
    }

    public void UpdatePoints(int obtainedPoints)
    {
        gamePoints = gamePoints + obtainedPoints; 

        gamePointsString = gamePoints.ToString();
        pointsDisplay.text = gamePointsString;

        Debug.Log("Mementos: "+gamePoints);
    }

    public void UpdatePlayerEnergy(int obtainedDamage)
    {
        this.actualPlayerEnergy = actualPlayerEnergy - obtainedDamage;
        //healthBar.SetHealth(actualPlayerEnergy);
        //Debug.Log("Energía: "+actualPlayerEnergy);
        
    }
    public bool DeathManager()
    {
        if(actualPlayerEnergy < 1)
        {
            alive = false;
        }

        return alive;
    }





}
