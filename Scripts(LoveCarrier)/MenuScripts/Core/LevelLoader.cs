using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace LevelManagement
{
    public class LevelLoader : MonoBehaviour
    {
        private static int _mainMenuIndex = Constants.Settings.DefaultLevelIndex;

        public static void LoadLevel(string levelName)
        {
            Scene nextScene = SceneManager.GetSceneByName(levelName);

            if (nextScene.IsValid())
            {
                SceneManager.LoadScene(levelName);
            }
            else
            {
                Debug.LogWarning("LEVELLOADER LoadLevel Error: invalid scene specified!");
            }
        }

        public static void LoadLevel(int levelIndex)
        {
            if (levelIndex >= 0 && levelIndex < SceneManager.sceneCountInBuildSettings)
            {
                //if (levelIndex == _mainMenuIndex)
                //{
                //    MainMenu.Open();
                //}

                SceneManager.LoadScene(levelIndex);
            }
            else
            {
                Debug.LogWarning("LEVELLOADER LoadLevel Error: invalid scene specified!");
            }
        }

        public static void ReloadLevel()
        {
            LoadLevel(SceneManager.GetActiveScene().name);
        }

        public static void LoadNextLevel()
        {
            int nextSceneIndex = (SceneManager.GetActiveScene().buildIndex + 1)
                % SceneManager.sceneCountInBuildSettings;


            if (nextSceneIndex == Constants.Settings.DefaultLevelIndex-1)
            {
                PlayerPrefs.SetInt(Constants.Settings.IsRandom, 1);
            }

            // nextSceneIndex = Mathf.Clamp(nextSceneIndex, _mainMenuIndex, nextSceneIndex);

            int value = PlayerPrefs.GetInt(Constants.Settings.LevelIndex, Constants.Settings.DefaultLevelIndex);
            value++;

            PlayerPrefs.SetInt(Constants.Settings.LevelIndex, value);

            int _randomLevels = PlayerPrefs.GetInt(Constants.Settings.IsRandom, Constants.Settings.DefaultIsRandom);

            LevelIndexScripts.TextYazdir(value);

            if (_randomLevels == 1)
            {
                var randNumber = Random.Range(2, SceneManager.sceneCountInBuildSettings);

                LoadLevel(randNumber);
            }
            else
            {
                LoadLevel(nextSceneIndex);
            }
        }

        public static void LoadMainMenuLevel()
        {
            LoadLevel(_mainMenuIndex);
        }

    }
}