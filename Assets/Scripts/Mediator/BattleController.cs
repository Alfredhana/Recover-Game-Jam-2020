using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleController : MonoBehaviour
{
    private ICharacter player;
    private ICharacter enemy;

    public ICharacter Player
    {
        set { player = value; }
        get { return player; }
    }
    public ICharacter Enemy
    {
        set { enemy = value; }
        get { return enemy; }
    }

    public void Attack(int demage, ICharacter character)
    {
        if (character == player)
        {
            enemy.Demage(demage);
        }
        else
        {
            player.Demage(demage);
        }
    }

    public void BlockRoad(int n, ICharacter character)
    {
        if (character == player)
        {
            StartCoroutine(enemy.BlockSelfRoad(n));
        }
        else
        {
            StartCoroutine(player.BlockSelfRoad(n));
        }
    }

    public void BlinkRoad(int n, ICharacter character)
    {
        if (character == player)
        {
            enemy.BlinkSelfRoad(n);
        }
        else
        {
            player.BlinkSelfRoad(n);
        }
    }

    public Vector2 GetOpponentPosition(ICharacter character)
    {
        Vector2 pos;
        if (character == player)
        {
            pos = enemy.GetTerrain(enemy.Position).transform.position;
        }
        else
        {
            pos = player.GetTerrain(enemy.Position).transform.position;
        }
        return pos;
    }

    public void PutMask(bool isMaskOn, ICharacter character)
    {
        if (character == player)
        {
            enemy.PutMask(isMaskOn);
        }
        else
        {
            player.PutMask(isMaskOn);
        }

    }
}
