using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Co1umbine
{
    public class MeasureTwoPosition : MonoBehaviour
    {
        public string label;

        public Transform t1;
        public Transform t2;

        public bool useThreshold = false;
        public float threshold = 0.1f;

        // Update is called once per frame
        private float lastValue = 0;

        void Update()
        {

            if (t1 != null && t2 != null)
            {
                var magnitude = (t1.position - t2.position).magnitude;

                if (Mathf.Approximately(lastValue, magnitude)) return;

                if (useThreshold && (t1.position - t2.position).magnitude <= threshold)
                {
                    if (lastValue < (t1.position - t2.position).magnitude)
                    {
                        Debug.Log($"[{label}] {(t1.position - t2.position).magnitude}  peak!");
                    }
                    else
                    {
                        Debug.Log($"[{label}] {(t1.position - t2.position).magnitude}");
                    }
                }
                else if (!useThreshold)
                {
                    if (lastValue < (t1.position - t2.position).magnitude)
                    {
                        Debug.Log($"[{label}] {(t1.position - t2.position).magnitude}  peak!");
                    }
                    else
                    {
                        Debug.Log($"[{label}] {(t1.position - t2.position).magnitude}");
                    }
                }
                lastValue = (t1.position - t2.position).magnitude;
            }
        }
    }
}