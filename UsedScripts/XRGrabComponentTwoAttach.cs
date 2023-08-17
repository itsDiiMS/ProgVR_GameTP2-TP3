using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
public class XRGrabComponentTwoAttach : XRGrabInteractable
{
    public Transform leftAttachPoint;
    public Transform rightAttachPoint;
    protected override void OnSelectEntered(SelectEnterEventArgs args)
    {

        if(args.interactorObject.transform.CompareTag("LeftHand"))
        {

            attachTransform = leftAttachPoint;
        }


        else if(args.interactorObject.transform.CompareTag("RightHand"))
        {

            attachTransform = rightAttachPoint;
        }
        base.OnSelectEntered(args);
    }
}
