using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LevelManagement;
public class GameMan : MonoBehaviour
{
    public static bool botWin;
    public static bool playerWin;

    //public enum gameState
    //{
    //    entry,
    //    gameplay,
    //    end,
    //}
    //public gameState myState;


    void Start()
    {
        //myState = gameState.entry;
        botWin = false;
        playerWin = false;
        MainMenu.Open();
    }

    
    public void OpenWin() 
    {
        WinScreen.Open();
    }
    public void OpenLose() 
    {
        DieScreen.Open();
    }
   
}
