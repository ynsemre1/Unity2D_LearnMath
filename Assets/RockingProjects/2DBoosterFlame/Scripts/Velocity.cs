using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RockingProjects
{
    [System.Serializable]
    public class Velocity
    {
        public float angularVelocity {get; private set;}
        public Vector3 velocity {get; private set;}
        public float magnitudeRelativeToTargetDirection {get; private set;}

        private Vector2 _directionCache;
        private float _angleCache;
        private float _globalAngle;
        private Vector3 _positionCache;

        private GameObject _referenceObject;

        private Vector2 _targetDirectionInLocalSpace;

        public Velocity(GameObject referenceObject) {
            this._referenceObject = referenceObject;
            this._directionCache = this._referenceObject.transform.up;
            this._targetDirectionInLocalSpace = Vector2.up;
            this._positionCache = this._referenceObject.transform.position;
            this.magnitudeRelativeToTargetDirection = 0f;
        }

        private void computeVelocity() {
            this.velocity = _referenceObject.transform.position - _positionCache;
        }

        public void step() {
            computeVelocity();
            computeAngularVelocity();
            ComputeRelativeMagnitude();
            this._positionCache = this._referenceObject.transform.position;
            this._directionCache = this._referenceObject.transform.up;
            this._angleCache = _globalAngle;
        }

        private void computeAngularVelocity()
        {
            _globalAngle += Vector2.SignedAngle(_directionCache, _referenceObject.transform.up);
            this.angularVelocity = (_globalAngle - _angleCache) / Time.deltaTime;
        }

        private void ComputeRelativeMagnitude() {
            float velocityAngle = Vector2.Angle(this.velocity, _referenceObject.transform.TransformVector(this._targetDirectionInLocalSpace));
            float strength = Mathf.Cos(velocityAngle);
            this.magnitudeRelativeToTargetDirection = strength * this.velocity.magnitude;

        }

    }
    
}
