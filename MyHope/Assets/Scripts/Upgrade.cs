using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Upgrade : MonoBehaviour
{
    public UpgradeManager.types currentType;

    private void OnParticleCollision(GameObject other)
    {
        FMODUnity.RuntimeManager.PlayOneShot("event:/SFX/Bolhas Upgrade", transform.position);
        transform.parent.GetComponent<UpgradeManager>().ChooseUpgrade(currentType);
    }
}
