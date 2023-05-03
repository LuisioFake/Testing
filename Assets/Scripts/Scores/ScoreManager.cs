using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace YogaFlow
{
    public class ScoreManager : MonoBehaviour
    {
        private AudioSource manager;
        [SerializeField] private AudioClip retry;
        [SerializeField] private AudioClip getBetter;
        [SerializeField] private AudioClip excelent;
        private void Start()
        {
            manager = GetComponent<AudioSource>();
        }
        public void PlayRetry()
        {
            manager.clip = retry;
            manager.Play();
        }
        public void PlayGetBetter()
        {
            manager.clip = getBetter;
            manager.Play();
        }
        public void PlayExcelent()
        {
            manager.clip = excelent;
            manager.Play();
        }
    }
}