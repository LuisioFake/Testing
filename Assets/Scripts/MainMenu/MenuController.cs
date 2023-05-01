using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace YogaFlow
{
    public class MenuController : MonoBehaviour
    {
        [Header("Camera Rotation")]
        public Animator targetCamera;
        [Range(1, 60)]
        public float fullRotation = 1;

        [Header("Fade Settings")]
        public CanvasGroup canvas;
        [Range(0.1f, 10)]
        public float transitionTime = 1;
        [Range(0, 1)]
        public float targetOpacity = 0;
        private bool fadeIn = false;
        private bool fadeOut = false;
        private void Start()
        {
            targetCamera.speed /= fullRotation;
        }
        private void Update()
        {
            if (fadeIn == true && canvas.alpha < 1)
            {
                canvas.alpha += Time.deltaTime / transitionTime;

                if (canvas.alpha >= 1)
                {
                    fadeIn = false;
                }
            }

            if (fadeOut == true && canvas.alpha >= targetOpacity)
            {
                canvas.alpha -= Time.deltaTime / transitionTime;

                if (canvas.alpha == targetOpacity)
                {
                    fadeOut = false;
                }
            }
        }
        public void ShowObject()
        {
            fadeIn = true;
        }
        public void HideObject()
        {
            fadeOut = true;
        }
    }
}