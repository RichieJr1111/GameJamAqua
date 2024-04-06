using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class isNotHoveringButtons : MonoBehaviour
{
    public void OnMouseOver()
    {
        PlayerSpawner.isHoverButton = false;
    }
}
