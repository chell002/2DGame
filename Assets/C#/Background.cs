using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour
{
    [SerializeField] private Transform person;
    [SerializeField] private float speedRotateBG;
    private Transform trBG;
    private Renderer render;
    public float speed = 0.2f;


    private void Awake()
    {
        trBG = GetComponent<Transform>();
        render = GetComponent<Renderer>();
    }
    private void Update()
    {

        FollowBG();
    }
    private void FollowBG()
    {
        float x = Input.GetAxis("Horizontal");
        Vector3 axis = new Vector3(x, 0, 0);
        trBG.position = Vector2.Lerp(trBG.position, person.position, Time.deltaTime * speed);
        trBG.position = new Vector3(trBG.position.x, trBG.position.y, 0);
        if (axis.sqrMagnitude > 0.2f)
        {
            render.material.mainTextureOffset += new Vector2(axis.x * speedRotateBG * Time.deltaTime, 0);
        }

    }

}
