using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace YogaFlow
{
    public class MultiConnect : MonoBehaviour
    {
        public bool rightConnections = false;
        [System.Serializable]
        public class Connection
        {
            private Vector2 direction;
            public Vector2 Direction
            {
                get { return direction; }
                set { direction = value; }
            }
            private float angle;
            public float Angle
            {
                get { return angle; }
                set { angle = value; }
            }
            [Range(-180, 180)]
            public float rotation = 0f;
            public float tolerance = 10f;
            private bool correct = false;
            public bool Correct
            {
                get { return correct; }
                set { correct = value; }
            }
            public Transform target;
            private Transform relativeTo;
            public Transform RelativeTo
            {
                get { return relativeTo; }
                set { relativeTo = value; }
            }
        }
        public List<Connection> connections;
        private int gamePoints;
        private void Start()
        {
            gameObject.transform.rotation = Quaternion.Euler(0, 0, 0);
            foreach (Connection connection in connections)
            {
                connection.RelativeTo = new GameObject($"Rotation [{connection.rotation}]").transform;
                connection.RelativeTo.transform.SetParent(gameObject.transform);
                connection.RelativeTo.position = gameObject.transform.position;
                connection.RelativeTo.rotation = Quaternion.Euler(0, 0, connection.rotation);
            }
        }
        private void Update()
        {
            gamePoints = 0;

            foreach (Connection connection in connections)
            {
                connection.Direction = connection.target.position - connection.RelativeTo.position;
                connection.Angle = Vector2.Angle(connection.Direction, connection.RelativeTo.up);

                if (connection.Angle <= connection.tolerance)
                {
                    connection.Correct = true;
                }
                else
                {
                    connection.Correct = false;
                }

                if (connection.Correct == true)
                {
                    gamePoints++;
                }
            }

            if (gamePoints == connections.Count)
            {
                rightConnections = true;
            }
            else
            {
                rightConnections = false;
            }
        }
        private void OnDrawGizmos()
        {
            foreach (Connection connection in connections)
            {
                try
                {
                    Gizmos.DrawLine(connection.RelativeTo.position, connection.target.position);
                }
                catch { }
            }
        }
    }
}