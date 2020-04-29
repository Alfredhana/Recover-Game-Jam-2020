using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public Transform firePoint;
    public GameObject impactEffect;
    public ICharacter owner;
    public LineRenderer lineRenderer;

    public void Awake()
    {
        owner = GetComponent<ICharacter>();
    }

    public IEnumerator Shoot()
    {
        RaycastHit2D hitInfo = Physics2D.Raycast(firePoint.position, firePoint.right);

        if (hitInfo)
        {
            ICharacter character = hitInfo.transform.GetComponent<ICharacter>();
            if (character != null)
            {
                owner.Attack(owner.ATK);
            }
            SpawnBloom(hitInfo.point);
            lineRenderer.SetPosition(0, firePoint.position);
            lineRenderer.SetPosition(1, hitInfo.point);
        }
        else
        {
            lineRenderer.SetPosition(0, firePoint.position);
            lineRenderer.SetPosition(1, firePoint.position + firePoint.right * 100);
        }
        lineRenderer.enabled = true;

        yield return new WaitForSeconds(.5f);

        lineRenderer.enabled = false;
    }


    public void SpawnBloom(Vector2 position)
    {
        Instantiate(impactEffect, position, Quaternion.identity);
    }
}
