using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Data;

namespace NonMonobech
{
    public class NextSceneLoader
    {
        public async void LoadNextScene()
        {
            int nextScene = GameProgressManager.Instance.LvlCount++;

            if (nextScene <= SceneManager.sceneCountInBuildSettings) // если текущая сцена не является последней - загружаем следующую
            {
                AsyncOperation loadOperation = SceneManager.LoadSceneAsync(nextScene);
                loadOperation.allowSceneActivation = false;

                while (!loadOperation.isDone)
                {
                    if (loadOperation.progress >= 0.9f)
                    {
                        loadOperation.allowSceneActivation = true;
                    }
                    await System.Threading.Tasks.Task.Yield();
                }
            }
        }
    }
}
