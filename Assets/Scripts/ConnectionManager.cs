using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
        [Header("Testing")]
        public bool testBool = false;
        public bool active = true;
        public float timer = 0;
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
        }
        private void Update()
        {
            connections = FindObjectsOfType<MultiConnect>();
            gamePoints = 0;
            foreach (MultiConnect connect in connections)
            {
                if (connect.rightConnections == true)
                {
                    gamePoints++;
                }
            }

            //if (gamePoints == connections.Length && connections.Length != 0)
            //{
            //    meter.material = mTrue;
            //}
            //else
            //{
            //    meter.material = mFalse;
            //}

            textTimer.text = $"{Mathf.FloorToInt(timer):D2}";
            if (testBool == true && active == true)
            {
                meter.material = mTrue;
                timer += Time.deltaTime;
                if (timer > 5)
                {
                    StartCoroutine(Victory());
                }
            }
            else if (testBool == false && active == true)
            {
                meter.material = mFalse;
                timer = 0;
            }
        }
        IEnumerator Victory()
        {
            active = false;
            Debug.LogWarning("Has ganado");
            yield return new WaitForSeconds(5);
        }
        public void ResetGame()
        {
            active = true;
            timer = 0;
        }
    }
}