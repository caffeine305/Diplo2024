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

    string gamePointsString;
    string playerEnergyString;
    public bool alive;

    //public LifebarManager healthBar;
    public TMP_Text pointsDisplay;
    public TMP_Text energyDisplay;
    //public GameObject gameOverPanel;

    void Start()
    {
        //gameOverPanel.SetActive(false);
        bossMaxEnergy = 200;
        playerMaxEnergy = 500;
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
        if(actualPlayerEnergy > 1)
        {
            this.actualPlayerEnergy = actualPlayerEnergy - obtainedDamage;
            int visualEnergy = Mathf.RoundToInt(actualPlayerEnergy/5);
            playerEnergyString = visualEnergy.ToString();
            energyDisplay.text = playerEnergyString; 

        //healthBar.SetHealth(actualPlayerEnergy);
        }
        else
        {
            actualPlayerEnergy = 0;
        }
            Debug.Log("Energía: "+actualPlayerEnergy);
        
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
