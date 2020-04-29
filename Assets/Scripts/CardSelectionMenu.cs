using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardSelectionMenu : MonoBehaviour
{
    CardsController cardsController;
    public Sprite[] cardSprites;
    public GameObject popMenu;
    public GameObject cursor;
    public GameObject okayButton;
    public Image[] skills;
    bool[] isSkillSelected;
    public Image[] selectedSkills;
    int position;
    int chosens;
    int maxSkill;

    Dictionary<Sprite, int> skillDict;

    public void Awake()
    {
        maxSkill = skills.Length - 1;
        chosens = -1;
        isSkillSelected = new bool[skills.Length];
        cardsController = FindObjectOfType<CardsController>();
        skillDict = new Dictionary<Sprite, int>();
    }

    public void Clear()
    {
        maxSkill = skills.Length - 1;
        chosens = -1;
        for (int i = 0; i < skills.Length; i++)
        {
            isSkillSelected[i] = false;
            selectedSkills[i].gameObject.SetActive(false);
        }
        position = 0;
        cursor.GetComponent<RectTransform>().position = skills[0].transform.position;
        GenerateCardChips();
        cardsController.Clear();
        skillDict = new Dictionary<Sprite, int>();
    }
    public void GenerateCardChips()
    {
        int length = skills.Length;
        for (int i = 0; i < length; i++)
        {
            int randN = Random.Range(0, 4);
            //int randN = 0;
            skills[i].sprite = cardSprites[randN];
            if (!skillDict.ContainsKey(cardSprites[randN]))
                skillDict.Add(cardSprites[randN], randN);
        }
        Debug.Log("New Cards Queue Generated");
    }

    public void PopMenuSlideIn()
    {
        float x = Camera.main.transform.position.x;

        float y = Camera.main.transform.position.y;
        popMenu.GetComponent<RectTransform>().anchoredPosition =  new Vector2(160, 0);
    }

    public void PopMenuSlideOut()
    {
        popMenu.GetComponent<RectTransform>().anchoredPosition = new Vector2(-160, 0);
    }

    public void CursorMoveForward()
    {
        if (position < maxSkill)
        {
            cursor.GetComponent<RectTransform>().position = skills[++position].transform.position;
        }
        else
        {
            if (!CursorOnOkayButton())
                position++;
            cursor.GetComponent<RectTransform>().position = okayButton.transform.position;
        }
    }

    public void CursorMoveBackward()
    {
        if (position > maxSkill)
        {
            cursor.GetComponent<RectTransform>().position = skills[--position].transform.position;
        }
        else if (position > 0)
        {
            cursor.GetComponent<RectTransform>().position = skills[--position].transform.position;
        }
    }

    public bool CursorOnOkayButton()
    {
        return position > maxSkill;
    }

    public void SelectSkill()
    {
        if (chosens < maxSkill)
        {
            if (!isSkillSelected[position])
            {
                selectedSkills[++chosens].sprite = skills[position].sprite;
                selectedSkills[chosens].gameObject.SetActive(true);
                isSkillSelected[position] = true;
                cardsController.AddCard(skillDict[skills[position].sprite]);
            }
        }
    }
}
