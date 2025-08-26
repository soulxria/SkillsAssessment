using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformCode : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        MeshRenderer renderer = GetComponent<MeshRenderer>();
        if (renderer != null)
        {
            renderer.material.color = Color.blue;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
