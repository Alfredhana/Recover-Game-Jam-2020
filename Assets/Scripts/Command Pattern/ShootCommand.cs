using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootCommand : Command
{
    public ShootCommand(ICharacter receiver) : base(receiver) { }
    public override void Execute()
    {
        receiver.Shoot();
    }
}
