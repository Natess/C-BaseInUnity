using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Random = UnityEngine.Random;

namespace Maze
{
    public class BadBonusSpeed : BadBonus
    {
        public float SpeedModifier { get; protected set; }
        public event Action<float> OnCaughtPlayer = delegate (float _speedModifier) { };

        protected override void Awake()
        {
            base.Awake();
            SpeedModifier = Random.Range(0.2f, 0.7f);
        }

        protected override void Interaction()
        {
            OnCaughtPlayer?.Invoke(SpeedModifier);
        }
    }
}