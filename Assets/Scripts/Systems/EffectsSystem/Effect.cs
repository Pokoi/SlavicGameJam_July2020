using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Garden
{
    public abstract class Effect : MonoBehaviour
    {
        public abstract void Execute();

        private bool active;

        public bool IsActive => active;
    }
}