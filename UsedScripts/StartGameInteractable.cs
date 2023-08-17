using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using Unity.XR.CoreUtils;
using UnityEditor;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class StartGameInteractable : MonoBehaviour
{

    PlatformMovement platform;

    private void Start()
    {

  
        XRGrabInteractable grabbable = GetComponent<XRGrabInteractable>();
        grabbable.activated.AddListener(StartPlatform);
    }
    public void StartPlatform(ActivateEventArgs arg) 
    {
        platform = GameObject.FindGameObjectWithTag("StartPlatform").GetComponent<PlatformMovement>();
        platform.PlatformTranslation(true);
        Destroy(gameObject);
    }
}