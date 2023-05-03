using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
namespace YogaFlow
{
    public class Achievements : MonoBehaviour
    {
        [System.Serializable]
        public class CompleteExercises
        {
            public string name;
            [TextArea]
            public string description;
            public DifficultyState inDifficulty;
            public enum DifficultyState
            {
                any, normal, hard, expert
            }
            public RequisiteState requisite;
            public enum RequisiteState
            {
                quantity, Seconds
            }
            public int inQuantity;
            public float inSeconds;
            public ProgressState progress;
            public enum ProgressState
            {
                notCompleted, completed
            }
        }
        public List<CompleteExercises> exerciseAchievements;
    }
}