using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public abstract class ICharacter : IReceiver
{
    public bool canMove;
    public bool canAttack;
    public SpriteRenderer spriteRenderer;
    public Material matOriginal;
    public Material matWhite;
    public void ResetMaterial()
    {
        spriteRenderer.material = matOriginal;
    }
    protected BattleController mediator;
    public BattleController Mediator
    {
        set { mediator = value; }
        get { return mediator; }
    }
    public Weapon weapon;
    public int life;
    public SpriteRenderer skillImage;
    public GameObject lifeText;
    public GameObject yellText;
    public GameObject mask;
    public GameObject boostIcon;
    public GameManager gameManager;
    public int maxDemage;
    public int demage;
    public int ATK
    {
        get { return demage; }
        set {
            if (value < 0)
                demage = 0;
            else if (value > maxDemage)
                demage = maxDemage;
            else 
                demage = value;
        }
    }
    protected int position; // in middle terrein
    public int Position {
        set { position = value; }
        get { return position; } }
    public TerrainsManager terrainsManager;

    public void Awake()
    {
        gameManager = FindObjectOfType<GameManager>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        terrainsManager = FindObjectOfType<TerrainsManager>();
        weapon = GetComponent<Weapon>();
        position = 4;
        life = 1500;
        demage = 100;
    }
    public void MoveForward()
    {
        if (position < 8)
        {
            Terrain terrain = GetTerrain(position + 1);
            if (!terrain.isDemaged)
            {
                position += 1;
                transform.position = terrain.transform.position;
            }
        }
    }
    public void MoveBackward()
    {
        if (position > 0)
        {
            Terrain terrain = GetTerrain(position - 1);
            if (!terrain.isDemaged)
            {
                position -= 1;
                transform.position = terrain.transform.position;
            }
        }
    }
    public void MoveDown()
    {
        if (position < 6)
        {
            Terrain terrain = GetTerrain(position + 3);
            if (!terrain.isDemaged)
            {
                position += 3; 
                transform.position = terrain.transform.position;
            }
        }
    }
    public void MoveUp()
    {
        if (position > 2)
        {
            Terrain terrain = GetTerrain(position - 3);
            {
                position -= 3;
                transform.position = terrain.transform.position;
            }
        }
    }

    public void MoveTo(int index)
    {
        position = index;
        transform.position = GetTerrain(index).transform.position;
    }

    public void Shoot()
    {
        StartCoroutine(weapon.Shoot());
    }

    public IEnumerator Yell(int index, Sprite sprite)
    {
        skillImage.sprite = sprite;

        yield return new WaitForSeconds(1f);

        skillImage.sprite = null;

        //yellText.GetComponent <TextMeshProUGUI>().text = SkillType.Type[index];
    }

    public void Demage(int demage)
    {
        spriteRenderer.material = matWhite;
        Debug.Log("You got me");
        if (life > 0)
        {
            life -= demage;
            Debug.Log("Life"+ life);
            Debug.Log("demage" + demage);
            lifeText.GetComponent<TextMeshProUGUI>().text = life.ToString();
            Invoke("ResetMaterial", .1f);
        }
        else
        {
            Die();
        }
    }

    public void Attack(int attack)
    {
        mediator.Attack(attack, this);
    }

    public void BlockRoad(int n)
    {
        mediator.BlockRoad(n, this);
    }

    public IEnumerator BlockSelfRoad(int n)
    {
        Debug.Log("Trying to Block Road");
        List<int> nums = new List<int>();
        for (int i = 0; i < n; i++)
        {
            int index;
            while (true)
            {
                index = Random.Range(0, 8);
                if (index != position && !GetTerrain(index).isDemaged)
                    break;
            }
            nums.Add(index);
            SetTerrainSprite(index, true);
        }
        yield return new WaitForSeconds(2);

        Debug.Log("Finish Blocking");
        foreach (int i in nums)
        {
            SetTerrainSprite(i, false);
        }
    }

    public void BlinkSelfRoad(int i)
    {
        SetTerrainBlink(i);
    }

    public void BlinkOpponentRoad(int i)
    {
        mediator.BlinkRoad(i, this);
    }

    public IEnumerator WearMask()
    {
        Vector2 pos = transform.position;
        transform.position = mediator.GetOpponentPosition(this) - new Vector2(1, 0);

        yield return new WaitForSeconds(1.5f);

        canAttack = false;
        mediator.PutMask(true, this);
        transform.position = pos;

        yield return new WaitForSeconds(6f);

        canAttack = true;
        mediator.PutMask(false, this);
    }

    public void PutMask(bool isMaskOn)
    {
        mask.SetActive(isMaskOn);
    }

    public IEnumerator BoostATK(float time)
    {
        ATK += 100;
        boostIcon.SetActive(true);

        Vector3 scale = boostIcon.transform.localScale;

        float i = 0.0f;
        float rate = (1.0f / time) * 2f;
        while (i < .5f)
        {
            i += Time.deltaTime * rate;
            boostIcon.transform.localScale = new Vector3(i, i, 0);
            yield return null;
        }

        boostIcon.SetActive(false);

        boostIcon.transform.localScale = scale;

    }

    public abstract Terrain GetTerrain(int position);
    public abstract void SetTerrainSprite(int i, bool isBroken);
    public abstract void SetTerrainBlink(int i);

    public int UpdatePosition(int position)
    {
        this.position = position;
        return this.position;
    }
}
