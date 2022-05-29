using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Random = UnityEngine.Random;

namespace Maze
{
    public class BadBonus : Bonus, IFly, IRotation
    {
        private float _heightFly;
        private float _speedRotation;

        protected override void Awake()
        {
            base.Awake();
            _heightFly = Random.Range(1f, 2f);
            _speedRotation = Random.Range(5f, 15f);
        }

        public void Fly()
        {
            _transform.position = new Vector3(_transform.position.x, Mathf.PingPong(Time.fixedTime, _heightFly), _transform.position.z);
        }

        public void Rotate()
        {
            _transform.Rotate(Vector3.up * (Time.fixedDeltaTime * _speedRotation), Space.World);
        }

        public override void Update()
        {
            Fly();
            Rotate();
        }

        protected override void Interaction()
        {
        }
    }
}