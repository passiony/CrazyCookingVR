using System;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

/// <summary>
/// 食材
/// </summary>
public class IngredientPlate : MonoBehaviour
{
    public IngredientType ingredientType;
    private XRSimpleInteractable m_SinpleInteractable;
    private Transform xrOrigin;
    private bool hovering;

    public string[] IngredientArray =
    {
        "",
        "番茄",
        "胡萝卜",
        "土豆",
        "猪肉",
        "牛排",
        "蘑菇",
        "黄瓜",
        "番茄",
        "胡萝卜",
        "土豆",
        "猪肉",
        "牛排",
        "蘑菇",
        "黄瓜"
    };

    private void Awake()
    {
        m_SinpleInteractable = gameObject.AddComponent<XRSimpleInteractable>();
        m_SinpleInteractable.selectEntered.AddListener(OnSelectEntered);
        m_SinpleInteractable.hoverEntered.AddListener(OnHoverEnter);
        m_SinpleInteractable.hoverExited.AddListener(OnHoverExit);
    }

    private void OnHoverExit(HoverExitEventArgs arg0)
    {
        hovering = false;
        m_currentTime = 0;
    }

    private void OnHoverEnter(HoverEnterEventArgs arg0)
    {
        hovering = true;
    }

    private void OnSelectEntered(SelectEnterEventArgs arg)
    {
        var path = ingredientType.ToString();
        var prefab = Resources.Load<GameObject>(path);
        var go = GameObject.Instantiate(prefab);
        go.transform.position = transform.position;
        go.GetComponent<Ingredient>().Shoot(arg.interactorObject.transform);
    }

    private float m_currentTime;

    private void Update()
    {
        if (hovering)
        {
            m_currentTime += Time.deltaTime;
            if (m_currentTime > 2)
            {
                hovering = false;
                SpeechComponent.Instance.Play("这是"+IngredientArray[(int)ingredientType]);
            }
        }
    }
}