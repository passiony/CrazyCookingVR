using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Serialization;

/// <summary>
/// 食材切片
/// </summary>
public class HalfIngredient : BaseIngredient
{
    public float m_CookDuration = 5;
    public Color m_OriginColor = Color.white;
    public Color m_CookedColor = Color.gray;

    public bool Cooked;
    private float m_CurrentTime = 0;
    private MeshRenderer m_Renderer;

    protected override void Awake()
    {
        base.Awake();
        m_Renderer = gameObject.GetComponent<MeshRenderer>();
    }

    public override void Cooking()
    {
        m_CurrentTime += Time.deltaTime;

        //颜色变化
        var t = m_CurrentTime / m_CookDuration;
        var color = Color.Lerp(m_OriginColor, m_CookedColor, t);
        m_Renderer.material.color = color;

        if (m_CurrentTime >= m_CookDuration)
        {
            Cooked = true;
        }
    }
}