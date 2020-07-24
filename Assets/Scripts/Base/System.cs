using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Garden
{
    public abstract class System
    {
        bool active = true;

       public abstract void Update(float delta);

       public bool IsActive => active;

        public abstract void Init();
    }
}
