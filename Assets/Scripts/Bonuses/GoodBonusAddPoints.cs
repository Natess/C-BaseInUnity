using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Maze
{
    internal class GoodBonusAddPoints : GoodBonus
    {
        [SerializeField]protected int _point = 1;
        public event Action<int> OnCaughtPlayer = delegate (int i) { };

        protected override void Interaction()
        {
            OnCaughtPlayer?.Invoke(_point);
        }
    }
}
