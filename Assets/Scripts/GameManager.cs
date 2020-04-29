using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public CardsController cardsController;
    public CardSelectionMenu cardSelectionMenu;
    public TimerBarController timerBarController;
    public EnemyController enemyController;
    public GameObject losePanel;
    public GameObject winPanel;
    BattleController mediator;
    public float sliderTime;
    public ICharacter player;
    public ICharacter enemy;
    bool endGame;
    bool won;
    public void Awake()
    {
        timerBarController.maxTime = sliderTime;
        mediator = GetComponent<BattleController>();
        enemyController = GetComponent<EnemyController>();
        player.Mediator = mediator;
        enemy.Mediator = mediator;
        mediator.Player = player;
        mediator.Enemy = enemy;
    }

    public void Start()
    {
        PopMenuSlideIn();
    }

    public void Update()
    {
        if (endGame)
        {
            if (Input.GetKeyDown(KeyCode.Return))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
            }
            return;
        }
        if (!player.canMove)
        {
            Debug.Log("Choosing chip");
            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                cardSelectionMenu.CursorMoveBackward();
            }
            else if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                cardSelectionMenu.CursorMoveForward();
            }
            else if (Input.GetKeyDown(KeyCode.Return))
            {
                if (cardSelectionMenu.CursorOnOkayButton())
                {
                    StartBattle();
                }
                else
                {
                    cardSelectionMenu.SelectSkill();
                }
            }
        }
        else
        {
            timerBarController.StartTimer();
            if (Input.GetKeyDown(KeyCode.A))
            {
                // release skill
                cardsController.UseCard(player);
            }

            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                player.MoveUp();
            }
            else if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                player.MoveForward();
            }
            else if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                player.MoveBackward();
            }
            else if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                player.MoveDown();
            }

            if (timerBarController.timesup)
            {
                if (Input.GetKeyDown(KeyCode.R))
                {
                    Reset();
                }
            }
        }

    }
    void PopMenuSlideIn()
    {
        cardSelectionMenu.PopMenuSlideIn();
        Camera.main.transform.position += new Vector3(0, 0.75f, 0);
        cardSelectionMenu.GenerateCardChips();
    }
    void PopMenuSlideOut()
    {
        cardSelectionMenu.PopMenuSlideOut();
        Camera.main.transform.position -= new Vector3(0, 0.75f, 0);
    }

    private void Reset()
    {
        cardSelectionMenu.Clear();
        enemyController.PauseBattle();
        timerBarController.ResetTimer();
        PopMenuSlideIn();
        player.canMove = false;
    }

    public void StartBattle()
    {
        PopMenuSlideOut();
        player.canMove = true;
        enemyController.StartBattle();
        timerBarController.StartTimer();
    }

    public void LoseGame()
    {
        Reset();
        endGame = true;

        // Show Success or fail

        losePanel.SetActive(true);
    }

    public void WinGame()
    {
        endGame = true;

        // Show Success or fail

        winPanel.SetActive(true);
    }

    public void Respawn()
    {
        endGame = false;

        // Show Success or fail

        losePanel.SetActive(false);
    }
}
