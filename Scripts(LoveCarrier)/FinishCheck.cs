using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishCheck : MonoBehaviour
{
    //public static bool botWin;
    //public static bool playerWin;

    public PlayerCCont pm;
    public BotMovementCont bm;

    void Start()
    {
        
        GameMan.playerWin = false;
    }


    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.tag == "Player")
        {

            if (GameMan.botWin==false)
            {
                GameMan.playerWin = true;
                GameMan.botWin = false;
                pm.Win();
                bm.Lose();
            }

         


        }
        if (other.gameObject.tag == "Bot")
        {

            if (GameMan.playerWin==false)
            {
                GameMan.playerWin = false;
                GameMan.botWin = true;
                bm.Win();
                pm.Lose();
            }

          

        }
        //gameman.myState = GameMan.gameState.end;
        //print(gameman.myState);
    }



}
