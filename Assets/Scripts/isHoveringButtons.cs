using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class isHoveringButtons : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public void OnPointerEnter(PointerEventData pointerEventData)
    {
        PlayerSpawner.isHoverButton = true;
    }

    public void OnPointerExit(PointerEventData pointerEventData)
    {
        PlayerSpawner.isHoverButton = false;
    }
}
