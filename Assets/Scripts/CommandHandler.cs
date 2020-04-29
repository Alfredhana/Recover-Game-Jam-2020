using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;

public class CommandHandler : MonoBehaviour
{
    private List<Command> commands = new List<Command>();

    public void SetCommand(Command command)
    {
        commands.Add(command);
    }

    public void Notify()
    {
        
        foreach (Command command in commands)
        {
            command.Execute();
        }
    }
}
