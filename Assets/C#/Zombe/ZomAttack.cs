using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZomAttack : MonoBehaviour
{
    public float damage = 5;
    float timer;
    public float interval = 0.5f;
    bool isAttac = false;
    ChellHP chellHP;

    private void Awake()
    {
        chellHP = FindObjectOfType<ChellHP>();
    }

    void Update()
    {
        if (isAttac && timer < Time.time)
        {
            timer = Time.time + interval;
            chellHP.TakeDamage(damage);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            isAttac = true;
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            isAttac = false;
        }
    }
}
