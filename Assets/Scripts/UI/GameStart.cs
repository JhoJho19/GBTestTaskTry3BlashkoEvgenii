using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NonMonobech;
using Data;
using UnityEditor;

namespace UI
{
    public class GameStart : MonoBehaviour
    {
        NextSceneLoader loader;

        private void Start()
        {
            loader = new NextSceneLoader();
        }

        public void StartTheGame() 
        {
            loader.LoadNextScene();
        }

        public void RestartTheGame()
        {
            GameProgressManager.Instance.LvlCount = 1;
            loader.LoadNextScene();
        }
    }
}
