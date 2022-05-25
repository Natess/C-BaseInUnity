using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Maze
{
    public class Main : MonoBehaviour
    {
        private InputController _inputController;
        private ListExecuteObject _interactiveObjects;

        [SerializeField]
        private GameObject _player;

        void Awake()
        {
            _inputController = new InputController(_player.GetComponent<Unit>());
            _interactiveObjects = new ListExecuteObject();

            _interactiveObjects.Add(_inputController);
        }

        void Update()
        {
            foreach (IExecute item in _interactiveObjects)
            {
                if (item == null)
                    continue;

                item.Update();
            }
        }
    }
}
