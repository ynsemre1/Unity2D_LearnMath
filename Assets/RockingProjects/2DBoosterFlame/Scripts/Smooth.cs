using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RockingProjects {
    [System.Serializable]
    public class Smooth
    {
        private float velocity;
        [SerializeField] private float smoothTime = .1f;
        [SerializeField] private float maxSpeed = 1f;
        private float currentValue = 0f;

        public float smooth(float value) {
            float result = Mathf.SmoothDamp(currentValue, value, ref velocity, smoothTime, maxSpeed);
            currentValue = result;
            return result;
        }
        
    }

}
