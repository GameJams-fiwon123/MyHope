using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Upgrade : MonoBehaviour
{
    public UpgradeManager.types currentType;

    private void OnParticleCollision(GameObject other)
    {
        transform.parent.GetComponent<UpgradeManager>().ChooseUpgrade(currentType);
    }
}
