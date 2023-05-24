using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

namespace YogaFlow
{
    public class ConnectionManager : MonoBehaviour
    {
        public MultiConnect[] connections;
        private int gamePoints = 0;
        [Header("Difficulty")]
        public DifficultyState difficulty = DifficultyState.hard;
        public enum DifficultyState
        {
            normal, hard, expert
        }
        private float toleranceValue;
        public float Tolerance
        {
            get { return toleranceValue; }
            set { toleranceValue = value; }
        }
        private float normalValue = 30f;
        private float hardValue = 15f;
        private float expertValue = 5f;
        public ScoreManager score;
        public UnityEvent winEvent;
        [Header("Testing")]
        public bool testBool = false;
        public bool active = true;
        public float timer = 0;
        public float gameTimer = 0;
        public Text textTimer;
        public Renderer meter;
        public Material mFalse;
        public Material mTrue;
        private void Start()
        {
            if (difficulty == DifficultyState.normal)
            {
                toleranceValue = normalValue;
            }
            else if (difficulty == DifficultyState.hard)
            {
                toleranceValue = hardValue;
            }
            else
            {
                toleranceValue = expertValue;
            }
            Debug.Log($"La dificultad es: {difficulty}. Por lo que la tolerancia es {toleranceValue}");
            score = FindObjectOfType<ScoreManager>();
        }
        private void Update()
        {
            gameTimer += Time.deltaTime;

            connections = FindObjectsOfType<MultiConnect>();
            gamePoints = 0;
            foreach (MultiConnect connect in connections)
            {
                if (connect.rightConnections == true)
                {
                    gamePoints++;
                }
            }

            if (gamePoints == connections.Length && connections.Length != 0 && active == true)
            {
                meter.material = mTrue;
                timer += Time.deltaTime;
                if (timer > 5)
                {
                    StartCoroutine(Victory());
                }
            }
            else if (!(gamePoints == connections.Length && connections.Length != 0) && active == true)
            {
                meter.material = mFalse;
                timer = 0;
            }

            //textTimer.text = $"{Mathf.FloorToInt(timer):D2}";
            //if (testBool == true && active == true)
            //{
            //    meter.material = mTrue;
            //    timer += Time.deltaTime;
            //    if (timer > 5)
            //    {
            //        StartCoroutine(Victory());
            //    }
            //}
            //else if (testBool == false && active == true)
            //{
            //    meter.material = mFalse;
            //    timer = 0;
            //}

            if (connections.Length != 0 && gameTimer >= 600 && active == true)
            {
                StartCoroutine(Defeat());
            }

#if UNITY_EDITOR
            if (Input.GetKeyDown(KeyCode.O))
            {
                StartCoroutine(Defeat());
            }
            if (Input.GetKeyDown(KeyCode.P))
            {
                StartCoroutine(Victory());
            }
#endif
        }
        IEnumerator Victory()
        {
            active = false;
            Debug.LogWarning("Has ganado");

            if (gameTimer <= 60)
            {
                score.PlayExcelent();
            }
            else
            {
                score.PlayGetBetter();
            }
            yield return new WaitForSeconds(3);
            winEvent.Invoke();
        }
        IEnumerator Defeat()
        {
            active = false;
            Debug.LogWarning("Has perdido");
            score.PlayRetry();
            yield return new WaitForSeconds(3);
            ResetGame();
        }
        public void ResetGame()
        {
            active = true;
            timer = 0;
            gameTimer = 0;
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}