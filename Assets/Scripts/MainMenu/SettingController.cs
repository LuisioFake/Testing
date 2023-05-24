using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace YogaFlow
{
    public class SettingController : MonoBehaviour
    {
        private MusicManager music;
        private ScoreManager score;
        private void OnEnable()
        {
            FindManagers();
            UpdateManagers();
        }
        public void FindManagers()
        {
            if (music == null)
            {
                music = FindObjectOfType<MusicManager>();
            }
            if (score == null)
            {
                score = FindObjectOfType<ScoreManager>();
            }
        }
        public void UpdateManagers()
        {

        }
        public void MusicMute(TMP_Text tmp)
        {
            AudioSource manager = music.GetComponent<AudioSource>();
            manager.mute = !manager.mute;

            if (manager.mute == true)
            {
                tmp.text = "música: no";
            }
            else
            {
                tmp.text = "música: si";
            }
        }
        public void MusicVolume(Slider slider)
        {
            AudioSource manager = music.GetComponent<AudioSource>();
            manager.volume = slider.value;
        }
        public void ScoreMute(TMP_Text tmp)
        {
            AudioSource manager = score.GetComponent<AudioSource>();
            manager.mute = !manager.mute;

            if (manager.mute == true)
            {
                tmp.text = "efectos: no";
            }
            else
            {
                tmp.text = "efectos: si";
            }
        }
        public void ScoreVolume(Slider slider)
        {
            AudioSource manager = score.GetComponent<AudioSource>();
            manager.volume = slider.value;
        }
    }
}