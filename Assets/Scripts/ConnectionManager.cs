using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace YogaFlow
{
    public class ConnectionManager : MonoBehaviour
    {
        public MultiConnect[] connections;
        private int gamePoints = 0;
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

            if (gamePoints == connections.Length && connections.Length != 0)
            {
                Debug.Log("Ganaste");
            }
        }
    }
}