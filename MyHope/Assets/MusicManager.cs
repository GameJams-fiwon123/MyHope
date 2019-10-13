using FMODUnity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<StudioEventEmitter>().EventInstance.setVolume(0.4f);
    }
}
