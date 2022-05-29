using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Maze
{
    public class GoodBonus : Bonus, IFly, IFlicker
    {
        private float _heightFly = 3f;
        [SerializeField]private Material _material;

        protected override void Awake()
        {
            base.Awake();
            _material = GetComponent<Renderer>().material;
        }

        public override void Update()
        {
            Fly();
            Flick();
        }

        public void Flick()
        {
            _material.color = new Color(_material.color.r, _material.color.g, _material.color.b, Mathf.PingPong(Time.time, 1f));
        }

        public void Fly()
        {
            _transform.position = new Vector3(_transform.position.x, Mathf.PingPong(Time.time, _heightFly), _transform.position.z);
        }

        protected override void Interaction()
        {
        }
    }
}