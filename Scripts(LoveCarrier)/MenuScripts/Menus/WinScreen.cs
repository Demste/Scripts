﻿using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace LevelManagement
{
    public class WinScreen : Menu<WinScreen>
    {
        [SerializeField] private GameObject _winAnim;
      
        public void OnNextLevelPressed()
        {
            base.OnBackPressed();
            LevelLoader.LoadNextLevel();
        }
        public void OnRestartPressed()
        {
            base.OnBackPressed();
            LevelLoader.ReloadLevel();
        }
        public void OnMainMenuPressed()
        {
            LevelLoader.LoadMainMenuLevel();
            MainMenu.Open();
        }
    }
}