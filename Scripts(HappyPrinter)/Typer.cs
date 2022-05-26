using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Typer : MonoBehaviour
{
    PlayerMove pm;

    private TouchScreenKeyboard keyboard;
    public InputField input;
    public GameObject Player;
    public GameObject[] finish;


    private List<GameObject> Boyancaklar = new List<GameObject>();

    //publicti
    private  int next = 0;

    public WordList wordlist = null;
    public TextMeshPro wordOutput = null;

    private string remainingWord = string.Empty;
    private string currentWord = string.Empty;

    public static float finishstartpos;


    public GameObject[] Blank;

    private bool lose;

    public Instantiate ins;

    void Start()
    {

        keyboard = TouchScreenKeyboard.Open("", TouchScreenKeyboardType.Default);
        keyboard.active = true;
        SetCurrentWord();
        pm = FindObjectOfType<PlayerMove>().gameObject.GetComponent<PlayerMove>();
        finishstartpos = remainingWord.Length + 1f;

        Vector3 pos = new Vector3(finishstartpos, 0f, 4.5f);

        Instantiate(finish[0], pos, Quaternion.identity);

        for (int i = 0; i < remainingWord.Length; i++)
        {
            Vector3 poss = new Vector3(i+1, 0.505f, -1.8f);
            GameObject clone;
            clone=Instantiate(Blank[0], poss,Quaternion.Euler(90f,0f,0f));
            clone.GetComponent<TextMeshPro>().text = remainingWord.Substring(i,1);
            Boyancaklar.Add(clone);
        }

    }


    private void SetCurrentWord() 
    {
        currentWord = wordlist.GetWord();
        SetRemainingWord(currentWord);
    }
    private void SetRemainingWord(string newString)     
    {
        remainingWord = newString;
        wordOutput.text = remainingWord;
    } 

    // Update is called once per frame
    void Update()
    {
        //CheckInput();
        lose = BotMovement.finish;
        if (lose)
        {
            keyboard.active = false;
        }

    }

    public void CheckInput() 
    {
        //    if (Input.anyKeyDown)
        //    {

        //        string keyPressed = Input.inputString;


        //        if (keyPressed.Length==1)
        //        {
        //            EnterLetter(keyPressed);
        //        }
        //}
        if (input.text.Length > 0)
        {
            //Debug.Log(input.text.Length);
            string keysPressed = input.text.Substring(input.text.Length - 1, 1);

            if (keysPressed.Length == 1)
            {
                EnterLetter(keysPressed);
                input.text = "";
            }
        }
    }
    private void EnterLetter(string typedLetter) 
    {
        if (IsCorrectLetter(typedLetter))
        {
            next++;

            // RemoveLetter();
            if (IsWordComplete())
            {

                Player.GetComponent<PlayerMove>().Finish();
                keyboard.active = false;
                //SetCurrentWord();
                //finish
            }
            if (!lose)
            {
                ins.TrueLetterCube();
                pm.Walk();
                Paint();
            }

        }
        else
        {
            if (!lose)
            {
                ins.FalseLetterCube();
            }
           
        }
    }
    private bool IsCorrectLetter(string letter) 
    {
       return remainingWord.IndexOf(letter, next) == next;
        //return remainingWord.IndexOf(letter)== next;
    }
    //private void RemoveLetter() 
    //{
    //    string newString = remainingWord.Remove(0, 1);
    //    SetRemainingWord(newString);
    //    //changecolor
    //}
    private bool IsWordComplete() 
    {
        return remainingWord.Length==next;
    }
    private void Paint() 
    {
        Boyancaklar[next-1].GetComponent<TextMeshPro>().color = Color.green;
    }
}
