using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BT
{
    public abstract class BT_Tree : MonoBehaviour
    {

        private BT_Node _root = null;

        protected void Start()
        {
            _root = SetupTree();
        }

        private void Update()
        {
            if (_root != null)
                _root.Evaluate();
                Debug.Log(_root.Evaluate());
        }

        protected abstract BT_Node SetupTree();

    }

}
