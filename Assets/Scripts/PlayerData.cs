using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData 
{
    public static void SavePlayerLevel(int currentLevel)
    {
        PlayerPrefs.SetInt("playerCurrentLevel",currentLevel);
    }
    public static int GetCurrentLevelPlayer()
    {
        return PlayerPrefs.GetInt("playerCurrentLevel");
    }
    public static void SavePlayerPoint(int currentPoint)
    {
        PlayerPrefs.SetInt("playerCurrentPonint", currentPoint);
    }
    public static int GetCurrentPointPlayer()
    {
        return PlayerPrefs.GetInt("playerCurrentPonint");
    }
}
