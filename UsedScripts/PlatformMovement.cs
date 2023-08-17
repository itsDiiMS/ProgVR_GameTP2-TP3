using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlatformMovement : MonoBehaviour
{



    bool activated = false;
    float distanceParcourue = 0;
    public void PlatformTranslation(bool keyActivated)
    {
        if (keyActivated == true)
        {
            
            activated = true;

        }
        
    }





    void Update()
    {
        if (activated == true) 
        {
            float Ytranslate = Time.deltaTime * 6.05f / 10f;
            gameObject.transform.Translate(0f, Ytranslate, 0f);
            distanceParcourue += Ytranslate;
        }
        if (distanceParcourue >= 6.05f) 
        {        
            activated= false;
        }
    }





}
