using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Maze
{
    internal class BadBonusGameOver : BadBonus
    {
        public event Action<string, Color> OnCaughtPlayer = delegate (string str, Color color) { };

        protected override void Awake()
        {
            base.Awake();

            BonusType = BonusType.BadBonusGameOver;
        }

        protected override void Interaction()
        {
            OnCaughtPlayer?.Invoke(gameObject.name, _color);
        }
    }
}
