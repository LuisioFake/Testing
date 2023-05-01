using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace YogaFlow
{
    public class SceneController : MonoBehaviour
    {
        private static SceneController instance;
        private void Awake()
        {
            instance = GetInstance();
        }
        public SceneController GetInstance()
        {
            if (instance == null)
            {
                instance = this;
                DontDestroyOnLoad(gameObject);
            }
            else
            {
                Destroy(gameObject);
            }
            return instance;
        }
        public void GoTo(string sceneName)
        {
            SceneManager.LoadScene(sceneName, LoadSceneMode.Single);
        }
        public void Exit()
        {
            Application.Quit();
        }
    }
}