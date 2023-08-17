using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using Unity.XR.CoreUtils;
using UnityEditor;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class MainInteractable : MonoBehaviour
{

    public GameObject KeyTeleportMesh;
    PlayerKeysCount playerKeys;
    int keyCountsFor = 1;
    public Vector3 keyTeleportation;
    

    private void Start()
    {

        XRGrabInteractable grabbable = GetComponent<XRGrabInteractable>();
        grabbable.activated.AddListener(addKeyToPlayer);
        
    }

   
    

    public void addKeyToPlayer(ActivateEventArgs arg) 
    {
        playerKeys = GameObject.FindGameObjectWithTag("HasKeyCount").GetComponent<PlayerKeysCount>();
        playerKeys.keyFound(keyCountsFor);
        Destroy(gameObject);
        Instantiate(KeyTeleportMesh, keyTeleportation, Quaternion.identity);
    } 
}