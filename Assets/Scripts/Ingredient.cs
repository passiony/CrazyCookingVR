using System.Collections;
using System.Collections.Generic;
using UnityEngine;



/// <summary>
/// 食材
/// </summary>
public class Ingredient : BaseIngredient
{
    public GameObject[] childs;

    public void Cut()
    {
        foreach (var prefab in childs)
        {
             var go =GameObject.Instantiate(prefab);
             go.transform.position = transform.position;
        }
        Destroy(gameObject);
    }

    public void Shoot(Transform target)
    {
        gameObject.GetComponent<ProjectileMotion>().ShootToTarget(target);
    }
}