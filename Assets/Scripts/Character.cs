using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace YogaFlow
{
    public class Character : ICloneable
    {
        private Vector3 position;
        private Quaternion rotation;
        public Character(Vector3 characterPosition, Quaternion characterRotation)
        {
            position = characterPosition;
            rotation = characterRotation;
        }
        public ICloneable Clone()
        {
            return MemberwiseClone() as Character;
        }
    }
}