﻿using UnityEngine;
using UnityEngine.SceneManagement;

namespace ScenesLoader
{
    public class SceneLoader
    {
        public void MainMenu() => SceneManager.LoadSceneAsync(0);

        public void Game() => SceneManager.LoadSceneAsync(1);
    }
}