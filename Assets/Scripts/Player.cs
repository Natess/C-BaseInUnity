using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Maze
{
    public sealed class Player : Unit
    {
        public float Speed
        {
            get { return _speed; }
            set
            {
                if (value < 1f)
                    _speed = 1f;
                else if (value > 10f)
                    _speed = 10f;
                else _speed = value;
            }
        }

        protected override void Awake()
        {
            base.Awake();

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