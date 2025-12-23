using Unity.Mathematics;
using UnityEngine;

public class ChellAnim : MonoBehaviour
{
    Animator anim;
    ChellMove move;
    ChellHP HP;


    private void Awake()
    {
        anim = GetComponent<Animator>();
        move = GetComponent<ChellMove>();
        HP = GetComponent<ChellHP>();
    }

    private void OnEnable()
    {
        move.onJumpAnim += JumpAnim;
        move.onSliderAnim += SlideAnim;
        HP.OnDead += DeadAnim;
    }

    private void OnDisable()
    {
        move.onJumpAnim -= JumpAnim;
        move.onSliderAnim -= SlideAnim;
        HP.OnDead -= DeadAnim;

    }
    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        MoveAnim(x);
    }
    private void MoveAnim(float x)
    {
        anim.SetFloat("X", Mathf.Abs(x));
    }
    private void JumpAnim()
    {
        anim.SetTrigger("Jump");
    }
    private void SlideAnim(bool isSlide)
    {
        anim.SetBool("Slide", isSlide);
    }
    private void DeadAnim()
    {
        anim.SetTrigger("dead");
    }
}
