using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

/// <summary>
/// 餐盘
/// </summary>
public class MealPlate : MonoBehaviour
{
    protected List<BaseIngredient> ingredients = new List<BaseIngredient>();
    protected Rigidbody m_RigidBody;
    public Rigidbody Rigidbody => m_RigidBody;

    protected void Awake()
    {
        gameObject.tag = "MealPlate";
        m_RigidBody = gameObject.GetComponent<Rigidbody>();
    }

    public void AddIngredient(BaseIngredient obj)
    {
        ingredients.Add(obj);
    }

    public void RemoveIngredient(BaseIngredient obj)
    {
        ingredients.Remove(obj);
    }

    protected virtual void Update()
    {
        CheckUpSetDown();
    }

    protected void CheckUpSetDown()
    {
        Vector3 plateUpDirection = transform.up;
        Vector3 worldUpDirection = Vector3.up;

        float dotProduct = Vector3.Dot(plateUpDirection, worldUpDirection);
        if (dotProduct < 0)
        {
            RemoveAllChild();
        }
    }

    protected void RemoveAllChild()
    {
        foreach (var ingre in ingredients)
        {
            ingre.OutPlate();
        }

        ingredients.Clear();
        ;
    }
}