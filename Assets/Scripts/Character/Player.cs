using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : ICharacter
{

    public override void Die()
    {
        gameManager.WinGame();
    }
    public override void Restore()
    {
    }

    public override Terrain GetTerrain(int position)
    {
        return terrainsManager.playerTerrains[position];
    }
    public override void SetTerrainSprite(int i, bool isBroken)
    {
        if (isBroken)
        {
            terrainsManager.SetPlayerTerrainSpriteBroken(i);
        }
        else
        {
            terrainsManager.SetPlayerTerrainSpriteRecover(i);
        }
    }
    public override void SetTerrainBlink(int i)
    {
        terrainsManager.SetPlayerTerrainBlink(i);
    }
}
