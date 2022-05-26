using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Hyperflow.Utils;
using UnityEngine.SceneManagement;

namespace LevelManagement
{
    public class LevelIndexScripts : MonoBehaviour
    {
        public static Text _text;
        private void Start()
        {

        }
        private static int value;


        private void Awake()
        {
            _text = gameObject.GetComponent<Text>();

            
            value = PlayerPrefs.GetInt(Constants.Settings.LevelIndex, Constants.Settings.DefaultLevelIndex);
            

            if (_text)
                _text.text = $"LEVEL {value}";

            int loadingLevelIndex = value % SceneManager.sceneCountInBuildSettings;
            //loadingLevelIndex = loadingLevelIndex == 0 ? 1 : loadingLevelIndex; //eðer 0.leveli atlamak istersen bunu aç
            if (SceneManager.GetActiveScene().buildIndex == 0)
            {
                SceneManager.LoadScene(loadingLevelIndex);
            }
        }
        public static void TextYazdir(int index)
        {
            value = PlayerPrefs.GetInt(Constants.Settings.LevelIndex, Constants.Settings.DefaultLevelIndex);
            if (_text)
                _text.text = $"LEVEL {index}";
        }

    }
}