using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Maze
{
    public class BaseClass : MonoBehaviour  
    {
        [SerializeField] protected Rigidbody _rb;
        [SerializeField] protected Transform _transform;

        protected virtual void Awake()
        {
            _transform = GetComponent<Transform>();
            if (GetComponent<Rigidbody>() != null)
                _rb = GetComponent<Rigidbody>();
        }
    }
}
