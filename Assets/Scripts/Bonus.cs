using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Maze
{
    public abstract class Bonus : BaseClass, IExecute
    {
        private bool _isInteractable;
        public bool IsInteractable
        {
            get => _isInteractable;
            set
            {
                _isInteractable = value;
                GetComponent<Renderer>().enabled = value;
                GetComponent<Collider>().enabled = value;
            }
        }

        private void Awake()
        {
            _transform = GetComponent<Transform>();
        }

        void Start()
        {
            IsInteractable = true;
        }

        private void OnTriggerEnter(Collider other)
        {
            if(other.CompareTag("Player"))
            {
                Interaction();
                IsInteractable=false;
            }
        }

        protected abstract void Interaction();

        public abstract void Update();
    }
}