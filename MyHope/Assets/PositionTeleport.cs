using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionTeleport : MonoBehaviour
{
    public bool isEnabled = true;

    private void OnBecameInvisible()
    {
        isEnabled = false;
    }

    private void OnBecameVisible()
    {
        isEnabled = true;
    }
}
