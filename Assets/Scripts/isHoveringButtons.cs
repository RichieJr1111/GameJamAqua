using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class isHoveringButtons : MonoBehaviour
{
    public void OnMouseOver()
    {
        PlayerSpawner.isHoverButton = true;
    }
}
