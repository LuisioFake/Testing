using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace YogaFlow
{
    public class MusicManager : MonoBehaviour
    {
        public AudioClip[] music;
        private AudioSource manager;
        private void Awake()
        {
            DontDestroyOnLoad(this);
        }
        private void Start()
        {
            manager = GetComponent<AudioSource>();
            NextSong();
        }
        private void Update()
        {
            if (manager.time == manager.clip.length)
            {
                NextSong();
            }
        }
        private void NextSong()
        {
            if (music.Length != 0)
            {
                manager.clip = music[Random.Range(0, music.Length)];
                manager.Play();
            }
        }
    }
}