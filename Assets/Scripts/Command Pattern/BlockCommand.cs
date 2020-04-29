using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockCommand : Command
{
    public BlockCommand(ICharacter receiver) : base(receiver) { }
    int blockN;

    public override void Execute()
    {
        receiver.BlockSelfRoad(blockN);
    }


    public void SetBlockNum(int n)
    {
        blockN = n;
    }


}
