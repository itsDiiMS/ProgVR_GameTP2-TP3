using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerKeysCount : MonoBehaviour
{
    public int keysFound;

    public void keyFound(int key)
    {
        if (key == 1)
        {
            keysFound++;
        }
    }
}
