using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class IHitable : MonoBehaviour {
    public abstract void Hit(PowerHitInfo hi);
}
