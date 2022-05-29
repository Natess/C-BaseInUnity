using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Maze
{
    public sealed class ListExecuteObject : IEnumerator, IEnumerable
    {
        private IExecute[] _interactiveObjects;
        private int _index = -1;

        public object Current => _interactiveObjects[_index];
        public int Length => _interactiveObjects.Length;

        public bool MoveNext()
        {
            if(_index == Length-1)
            {
                Reset();
                return false;
            }
            else
            {
                _index++;
                return true;
            }
        }

        internal void Add(IExecute execute)
        {
            if (_interactiveObjects == null)
            {
                _interactiveObjects = new[] { execute };
                return;
            }

            Array.Resize(ref _interactiveObjects, Length + 1);
            _interactiveObjects[Length - 1] = execute;
        }

        public void Reset()
        {
            _index = -1;
        }

        public IEnumerator GetEnumerator()
        {
            return this;
        }
    }
}