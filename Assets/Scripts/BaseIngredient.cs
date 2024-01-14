using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

//Defines which kind of ingredient we use
public enum IngredientType : int
{
    None,
    Tomato, //番茄
    Carrot, //胡萝卜
    Potato, //土豆
    Pork, //猪肉
    Steak, //牛排
    Mushroom, //蘑菇
    Cucumber, //黄瓜
    HalfTomato, //半番茄
    HalfCarrot, //半胡萝卜
    HalfPotato, //半土豆
    HalfPork, //半猪肉
    HalfSteak, //半牛排
    HalfMushroom, //半蘑菇
    HalfCucumber, //半黄瓜
};

public class BaseIngredient : MonoBehaviour
{
    public IngredientType ingredientType;
    private Rigidbody m_Rigidbody;
    private XRGrabInteractable m_GrabInteractble;
    private bool FullIn = false;
    private MealPlate m_Plate;

    protected  virtual void Awake()
    {
        m_Rigidbody = gameObject.GetComponent<Rigidbody>();
        m_GrabInteractble = gameObject.GetComponent<XRGrabInteractable>();
        m_GrabInteractble.selectEntered.AddListener(OnSelectEnter);
        m_GrabInteractble.selectExited.AddListener(OnSelectExit);
    }

    private void OnSelectExit(SelectExitEventArgs arg0)
    {
        FullIn = false;
    }

    private void OnSelectEnter(SelectEnterEventArgs arg0)
    {
        OutPlate();
        m_Plate?.RemoveIngredient(this);
    }

    public void OutPlate()
    {
        m_Rigidbody.mass = 1;
        transform.SetParent(null);
        FullIn = false;
        
        var component = GetComponent<FixedJoint>();
        if (component)
        {
            component.connectedBody = null;
            Destroy(component);
        }
    }

    public void InPlate()
    {
        m_Rigidbody.mass = 0;
        transform.SetParent(m_Plate.transform, true);
        m_Plate.AddIngredient(this);
        
        var joint = gameObject.AddComponent<FixedJoint>();
        joint.connectedBody = m_Plate.Rigidbody;
        joint.connectedAnchor = new Vector3(0.0f, 0.5f, 0.0f);
    }

    public virtual void Cooking()
    {
    }

    void Update()
    {
        if (FullIn)
            return;
        var hits = Physics.RaycastAll(transform.position, Vector3.down, 0.5f);
        foreach (var hit in hits)
        {
            if (hit.collider.CompareTag("MealPlate"))
            {
                Vector3 newv = hit.transform.position - transform.position;
                m_Rigidbody.velocity = newv * 2;
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (FullIn)
            return;
        
        //底部发生碰撞，不做处理
        if (collision.contacts[0].normal.y < 0)
            return;
        
        if (collision.collider.CompareTag("MealPlate"))
        {
            m_Plate = collision.collider.GetComponentInParent<MealPlate>();
            if (m_Plate)
            {
                FullIn = true;
                InPlate();
            }
        }
    }
}