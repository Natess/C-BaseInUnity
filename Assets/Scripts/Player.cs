using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Maze
{
    public sealed class Player : Unit
    {
        void Awake()
        {
            _transform = transform;
            if (GetComponent<Rigidbody>() != null)
                _rb = GetComponent<Rigidbody>();
            
            _isDead = false;
            _health = 100;
        }

        void Update()
        {

        }

        public override void Move(float x, float y, float z)
        {
            if (_rb)
            {
                _rb.AddForce(new Vector3(x, y, z) * _speed);
            }
            else
            {
                Debug.Log("No Rigidbody");
            }
        }
    }
}