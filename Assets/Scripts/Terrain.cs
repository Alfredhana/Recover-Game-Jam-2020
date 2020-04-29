using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Terrain : IReceiver
{
    public bool isDemaged;

    public override void Die()
    {
        isDemaged = true;
    }

    public override void Restore()
    {
        isDemaged = false;
    }
}