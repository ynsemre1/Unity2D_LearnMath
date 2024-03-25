using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RockingProjects {
    public class Helper
    {
        public static float mapValue(float minFrom, float maxFrom, float valueBetweenMinFromAndMaxFrom, float targetMin, float targetMax) {
            float percent = Mathf.InverseLerp(minFrom, maxFrom, Mathf.Clamp(valueBetweenMinFromAndMaxFrom, minFrom, maxFrom));
            return Mathf.Lerp(targetMin, targetMax, percent);
        }
    }

}
