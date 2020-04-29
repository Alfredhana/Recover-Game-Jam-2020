using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public BattleController mediator;
    ICharacter enemy;
    int n;
    float randT;
    float randAttack;
    float timerT;
    float timerAttack;
    public void Start()
    {
        enemy = mediator.Enemy;
    }

    public void StartBattle()
    {
        randT = Random.Range(1.5f, 2.5f);
        randAttack = Random.Range(3, 4f);
        enemy.canMove = true;
        enemy.canAttack = true;
    }

    public void PauseBattle()
    {
        enemy.canMove = false;
        enemy.canAttack = false;
    }

    public void FixedUpdate()
    {
        if (enemy.canMove)
        {
            timerT += Time.deltaTime;
            timerAttack += Time.deltaTime;
            if (timerT > randT)
            {
                while (true)
                {
                    int randN = Random.Range(0, 8);
                    if (randN != n)
                    {
                        enemy.MoveTo(randN);
                        timerT = 0;
                        randT = Random.Range(1.5f, 2.5f);
                        return;
                    }
                }
            }
            if (enemy.canAttack)
            {
                if (timerAttack > randAttack)
                {
                    randAttack = Random.Range(3, 4f);
                    if (randAttack < 3.6f)
                    {
                        EnemyAttack(Random.Range(0, 8));
                        timerAttack = 0;
                    }
                }
            }
        }
    }

    void EnemyAttack(int n)
    {
        Debug.Log("Trying to attack");
        // 50% shoot
        if (n < 4)
        {
            enemy.Shoot();
        }
        // 50 % Block Road
        else if (n <= 8)
        {
            int m = Random.Range(0, 10);
            if (m <= 6)
            {
                enemy.BlockRoad(2);
            }
            else
            {
                enemy.BlockRoad(3);
            }
        }
        // 25 % Giant Attack
        else if (n <= 20)
        {
            enemy.BlinkOpponentRoad(0);
        }
    }
}
