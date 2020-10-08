using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class follow : MonoBehaviour
{
    [SerializeField]
    Transform followTarget;

    [SerializeField]
    bool x = false;

    [SerializeField]
    bool y = false;

    [SerializeField]
    bool z = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 newPos = followTarget.position;

        if(!x)
        {
            newPos.x = transform.position.x;
        }

        if(!y)
        {
            newPos.y = transform.position.y;
        }

        if(!z)
        {
            newPos.z = transform.position.z;
        }
        transform.position = newPos;
    }
}
