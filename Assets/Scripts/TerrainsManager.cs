using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TerrainsManager : MonoBehaviour
{
    public Terrain[] playerTerrains;
    public Terrain[] enemyTerrains;

    public Sprite playerTerrainBroken;
    public Sprite playerTerrain;
    public Sprite enemyTerrainBroken;
    public Sprite enemyTerrain;

    public IEnumerator SetPlayerTerrainBlink(int i)
    {
        SpriteRenderer sr = playerTerrains[i].gameObject.GetComponentInChildren<SpriteRenderer>();
        sr.gameObject.SetActive(true);

        yield return new WaitForSeconds(.5f);

        sr.gameObject.SetActive(false);
    }
    public IEnumerator SetEnemyTerrainBlink(int i)
    {
        SpriteRenderer sr = enemyTerrains[i].gameObject.GetComponentInChildren<SpriteRenderer>();
        sr.gameObject.SetActive(true);

        yield return new WaitForSeconds(.5f);

        sr.gameObject.SetActive(false);
    }

    public void SetPlayerTerrainSpriteRecover(int i)
    {
        playerTerrains[i].GetComponent<SpriteRenderer>().sprite = playerTerrain;
        playerTerrains[i].Restore();
    }
    public void SetPlayerTerrainSpriteBroken(int i)
    {
        playerTerrains[i].GetComponent<SpriteRenderer>().sprite = playerTerrainBroken;
        playerTerrains[i].Die();
    }
    public void SetEnemyTerrainSpriteRecover(int i)
    {
        enemyTerrains[i].GetComponent<SpriteRenderer>().sprite = enemyTerrain;
        enemyTerrains[i].Restore();
    }
    public void SetEnemyTerrainSpriteBroken(int i)
    {
        enemyTerrains[i].GetComponent<SpriteRenderer>().sprite = enemyTerrainBroken;
        enemyTerrains[i].Die();
    }
}
