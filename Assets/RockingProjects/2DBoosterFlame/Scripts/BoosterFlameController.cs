using System;
using UnityEngine;

namespace RockingProjects
{
    public class BoosterFlameController : MonoBehaviour
    {
        [SerializeField, Range(0f, 1f)] private float maxBend;
        [SerializeField] private float maxAngularVelocityForBending;

        [SerializeField] private Smooth smoothBending;

        [SerializeField, Range(0f, 1f)] private float minSquash;
        [SerializeField, Range(0f, 6f)] private float maxSquash;
        [SerializeField] private Smooth smoothSquashing;
        [SerializeField, Tooltip("The velocity where the flame is at maximum")] private float maxVelocity = 20f;

        [SerializeField, Range(0f, 2f)] private float minIntensity;
        [SerializeField, Range(0f, 2f)] private float maxIntensity;
        [SerializeField] private Smooth smoothIntensity;

        private Velocity velocity;
        private SpriteRenderer spriteRenderer;

        void Start()
        {
            spriteRenderer = GetComponent<SpriteRenderer>();
            velocity = new Velocity(gameObject);
        }

        void FixedUpdate() {
            velocity.step();
            float bend = computeBend();
            float squash = computeSquash();
            float intensity = computeIntensity();
            spriteRenderer.material.SetFloat("_bend", bend);
            spriteRenderer.material.SetFloat("_squash", squash);
            spriteRenderer.material.SetFloat("_intensity", intensity);
        }

        private float computeIntensity()
        {
            float intensity = Helper.mapValue(0f, this.maxVelocity, Mathf.Abs(velocity.velocity.magnitude), this.minIntensity, this.maxIntensity);
            return this.smoothIntensity.smooth(intensity);
        }

        private float computeSquash()
        {
            float squash = Helper.mapValue(-maxVelocity, maxVelocity, velocity.magnitudeRelativeToTargetDirection, maxSquash, minSquash);
            return this.smoothSquashing.smooth(squash);
        }

        private float computeBend() {
            float bend = Helper.mapValue(-maxAngularVelocityForBending, maxAngularVelocityForBending, velocity.angularVelocity, -maxBend, maxBend);
            float angle = Vector2.SignedAngle(velocity.velocity, transform.up);
            float bend2 = -Helper.mapValue(-1f, 1f, (float)System.Math.Sin((double) Helper.mapValue(-180f, 180f, angle, 0f, 2f * (float)System.Math.PI)), -maxBend, maxBend);
            float normalizedVelocity = Helper.mapValue(0f, maxVelocity, velocity.velocity.magnitude, 0f, 1f);
            bend2 *= normalizedVelocity;
            bend = bend + bend2;
            bend = Mathf.Clamp(bend, -maxBend, maxBend);
            return this.smoothBending.smooth(bend);
        }


    }
    
}
