using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VolumeManager : MonoBehaviour {
    private void Update()
    {
        AudioSource[] a;
        a = gameObject.GetComponentsInChildren<AudioSource>();
        for (int i = 0; i < a.Length; i++)
        {
            a[i].volume = PlayerPrefs.GetFloat("volume", 0.5f);
        }
    }
}
