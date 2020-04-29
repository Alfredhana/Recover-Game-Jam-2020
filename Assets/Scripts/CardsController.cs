using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardsController : MonoBehaviour
{
    static Queue<Card> cards = new Queue<Card>();
    CardSelectionMenu cardSelectionMenu;
    // Start is called before the first frame update

    private void Awake()
    {
        cardSelectionMenu = FindObjectOfType<CardSelectionMenu>();
    }


    public void Clear()
    {
        cards = new Queue<Card>();
    }

    public void AddCard(int i)
    {        
        cards.Enqueue(new Card(i));
    }

    public void UseCard(ICharacter character)
    {
        if (cards.Count <= 0)
            return;
        Card card = cards.Dequeue();
        int cardType = card.Use();
        StartCoroutine(character.Yell(cardType, cardSelectionMenu.cardSprites[cardType]));
        switch (cardType)
        {
            case 0:
                //player.MoveUp();
                StartCoroutine( character.WearMask());
                break;
            case 1:
                //player.MoveForward();
                character.Shoot();
                break;
            case 2:
                //player.MoveDown();
                StartCoroutine(character.BoostATK(4f));
                break;
            case 3:
                //player.MoveBackward();
                character.Attack(character.ATK);
                break;
            default:
                break;
        }
    }
}
