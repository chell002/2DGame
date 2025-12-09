using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharCam : MonoBehaviour
{
    Transform tr;
    Transform trTarg;

    private void Awake()
    {
        tr = transform;
        trTarg = FindObjectOfType<ChellMove>().transform;
    }

    private void LateUpdate()
    {
        tr.position = new Vector3(trTarg.position.x, trTarg.position.y, -10);

    }
}
