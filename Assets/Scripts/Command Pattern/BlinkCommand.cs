using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlinkCommand : Command
{
    List<int> blinkIndexs;

    public BlinkCommand(ICharacter receiver) : base(receiver) 
    {
        blinkIndexs = new List<int>();
    }

    public void SetBlinkIndex(int i)
    {
        blinkIndexs.Add(i);
    }


    public override void Execute()
    {
        foreach (int i in blinkIndexs)
        {
            receiver.SetTerrainBlink(i);
        }
    }
}
