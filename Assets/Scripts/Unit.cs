using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Maze
{
    public abstract class Unit : BaseClass
    {
        [SerializeField] protected static float _speed = 5;
        [SerializeField] protected static int _health = 100;
        [SerializeField] protected static bool _isDead;

        public abstract void Move(float x, float y, float z);
    }
}