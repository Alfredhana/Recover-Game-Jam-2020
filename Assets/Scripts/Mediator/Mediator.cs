using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Mediator : MonoBehaviour
{
    public abstract void Attack(int demage, ICharacter character); 
    public abstract void BlockRoad(int n, ICharacter character);
    public abstract void BlinkRoad(int n, ICharacter character);

}
