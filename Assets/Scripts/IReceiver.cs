using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class IReceiver : MonoBehaviour
{
    public abstract void Die();
    public abstract void Restore();
}
