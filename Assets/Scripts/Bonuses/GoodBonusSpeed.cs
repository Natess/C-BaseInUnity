using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Random = UnityEngine.Random;

namespace Maze
{
    internal class GoodBonusSpeed : GoodBonus
    {
        public float SpeedModifier { get; protected set; }
        public event Action<float> OnCaughtPlayer = delegate (float _speedModifier) { };

        protected override void Awake()
        {
            base.Awake();
            SpeedModifier = Random.Range(1.2f, 1.7f);
            BonusType = BonusType.GoodBonusSpeed;
        }

        protected override void Interaction()
        {
            OnCaughtPlayer?.Invoke(SpeedModifier);
        }
    }
}
