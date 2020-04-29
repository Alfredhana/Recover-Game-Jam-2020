using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Command
{
    protected ICharacter receiver;

    public Command(ICharacter receiver){
        this.receiver = receiver;
    }

    public abstract void Execute();
}
