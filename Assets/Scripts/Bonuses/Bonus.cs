using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Maze
{
    public abstract class Bonus : BaseClass, IExecute
    {
        private bool _isInteractable;
        protected Color _color;

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

        void Start()
        {
            IsInteractable = true;

            _color = Random.ColorHSV();

            if (TryGetComponent(out Renderer renderer))
            {
                renderer.sharedMaterial.color = _color;
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            if(IsInteractable && other.CompareTag("Player"))
            {
                Interaction();
                IsInteractable=false;
            }
        }

        protected abstract void Interaction();

        public abstract void Update();
    }
}