using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Garden
{
    public abstract class System 
    {
        bool active;

       public abstract void Update();

       public bool is_active => active;
    }

}
