using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class BreakableWall : MonoBehaviour
{
    PlayerKeysCount playerKeys;
    public int playerkeysfound = 0;
    
    // Start is called before the first frame update
    void Start()
    {
        playerKeys = GameObject.FindGameObjectWithTag("HasKeyCount").GetComponent<PlayerKeysCount>();
    }

    private void FixedUpdate()
    {
        playerkeysfound = playerKeys.keysFound;
        if (playerkeysfound >=5)
        {
            Destroy(gameObject);
        }

    }

}
