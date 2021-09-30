using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IControllable
{
    GameObject EnableControl();
    void DisableControl();
    bool IsControlled();
}
