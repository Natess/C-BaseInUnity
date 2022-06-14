using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

namespace Maze
{
    public struct BonusData
    {
        public BonusType BonusType;
        public bool IsInteractable;
        public SVect3 BonusPosition;
    }

    public abstract class Bonus : BaseClass, IExecute
    {
        public Vector3 Position { get => _transform.position; }
        public BonusType BonusType { get; set; }

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

    public enum BonusType
    {
        GoodBonus = 100,
        GoodBonusAddPoint = 101,
        GoodBonusSpeed = 102,

        BadBonus = 200,
        BadBonusGameOver = 201,
        BadBonusSpeed = 202
    }
}