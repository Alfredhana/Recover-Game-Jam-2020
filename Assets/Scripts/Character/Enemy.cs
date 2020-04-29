using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : ICharacter
{

    public override void Die()
    {
        Debug.Log("Enemy Died");
        gameManager.LoseGame();
    }
    public override void Restore()
    {
    }
    public override Terrain GetTerrain(int position)
    {
        this.position = position;
        return terrainsManager.enemyTerrains[position];
    }

    public override void SetTerrainSprite(int i, bool isBroken)
    {
        if (isBroken)
        {
            terrainsManager.SetEnemyTerrainSpriteBroken(i);
        }
        else
        {
            terrainsManager.SetEnemyTerrainSpriteRecover(i);
        }
    }
    public override void SetTerrainBlink(int i)
    {
        terrainsManager.SetEnemyTerrainBlink(i);
    }
}
