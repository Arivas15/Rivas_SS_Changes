using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SplitScreen : MonoBehaviour
{
    public Camera cam1;
    public Camera cam2;

    void Start()
    {
        cam1.rect = new Rect(0, 0, 0.5f, 1);
        cam2.rect = new Rect(0.5f, 0, 0.5f, 1);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
