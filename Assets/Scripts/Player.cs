using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Maze
{
    public sealed class Player : Unit
    {
        [SerializeField] private int _points;

        protected override void Awake()
        {
            base.Awake();
            
            _isDead = false;
            _health = 100;
            _points = 0;
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

        internal void SetSpeed(float speedModifier)
        {
            _speed *= speedModifier;
            if(_speed < 1f)
                _speed = 1f;
            if (_speed > 10f)
                _speed = 10f;
        }

        internal void AddPoints(int points)
        {
            _points += points;
        }
    }
}