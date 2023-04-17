using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace YogaFlow
{
    public class Character
    {
        private Vector3 position;
        private Quaternion rotation;
        public Character(Vector3 characterPosition, Quaternion characterRotation)
        {
            position = characterPosition;
            rotation = characterRotation;
        }
        public Character Clone()
        {
            return MemberwiseClone() as Character;
        }
    }
}