using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Chapter.Strategy {
    public class Drone : MonoBehaviour
    {
        //ray Parameters
        private RaycastHit _hit;
        private Vector3 _rayDirection;
        private float _rayAngle = -45;
        private float _rayDistance = 15;

        //movementParameters
        public float speed = 1;
        public float maxHeight = 5;
        public float weavingDistance = 1.5f;
        public float fallbackDistance = 20;

        private void Start()
        {
            _rayDirection = transform.TransformDirection(Vector3.back) * _rayDistance;
            _rayDirection = Quaternion.Euler(_rayAngle, 0.0f, 0f) * _rayDirection;
        }
        public void ApplyStrategy(IManeuverBehaviour strategy)
        {
            strategy.Maneuver(this);
        }
        private void Update()
        {
            Debug.DrawRay(transform.position, _rayDirection, Color.blue);

            if (Physics.Raycast(transform.position, _rayDirection, out _hit, _rayDistance))
            {
                if (_hit.collider)
                {
                    Debug.DrawRay(transform.position, _rayDirection, Color.green);
                }
            }
        }
    }
}
