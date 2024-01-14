using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class HandController : MonoBehaviour
{
    private XRRayInteractor m_RayInteractor;
    
    void Start()
    {
        m_RayInteractor = gameObject.GetComponentInChildren<XRRayInteractor>();
        m_RayInteractor.selectEntered.AddListener(OnSelectEnter);
    }

    private void OnSelectEnter(SelectEnterEventArgs arg0)
    {
        
    }

}
