using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChellMove : MonoBehaviour
{
    
    //public event Action<float> onMovePerson;
    //public event Action<bool> onJumpingPerson;
    //public event Action<bool> onSliderPerson;

    private Rigidbody2D rigidbodyPerson;
    private Transform transformPerson;
    //public Transform startPointBullet;
    //public Transform gun;

    public float speed = 5f;
    public float speedSlide = 20f;
    public float timeSlider = 1f;
    public float scale = 0.5f;
    public float jumpForce = 6f;
    private float horizontal = 0f;
    private float timer = 0.5f;

    private bool isSlider = false;
    private bool isJumping = false;
    private void OnEnable()
    {
        transform.localScale = new Vector3(scale, scale, scale);
    }
    
    void Start()
    {
        rigidbodyPerson = GetComponent<Rigidbody2D>();
        transformPerson = GetComponent<Transform>();
    }
    void Update()
    {
        Slider();
        if (isJumping)
        {
            Jumping();
            SliderToggle();
        }
        ScaleDirection();
        Moving();
    }
    private void SliderToggle()
    {
        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            timer = timeSlider;
            isSlider = true;
        }
    }
    private void Slider()
    {
        timer -= Time.deltaTime;
        isSlider = timer <= 0 ? false : true;
        //onSliderPerson.Invoke(isSlider);
        if (isSlider)
        {
            float slideDirection = Mathf.Sign(transformPerson.localScale.x); // Get direction based on facing side
            Vector3 target = transformPerson.position + new Vector3(2 * slideDirection, 0, 0);
            transformPerson.position = Vector3.MoveTowards(transformPerson.position, target, speedSlide * Time.deltaTime);
        }
    }
    private void Jumping()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rigidbodyPerson.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            //onJumpingPerson?.Invoke(true);
            isJumping = false;
        }

    }
    private void Moving()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        rigidbodyPerson.velocity = new Vector2(horizontal * speed, rigidbodyPerson.velocity.y);

        //onMovePerson?.Invoke(horizontal);
    }
    private void ScaleDirection()
    {
        if (horizontal < 0f)
        {
            //startPointBullet.rotation = Quaternion.Euler(new Vector3(0, 180, 0));
            transform.localScale = new Vector3(-scale, scale, scale);
        }
        else if (horizontal > 0f)
        {
            //startPointBullet.rotation = Quaternion.Euler(new Vector3(0, 0, 0));
            transform.localScale = new Vector3(scale, scale, scale);
        }

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
            isJumping = true;
    }
}
