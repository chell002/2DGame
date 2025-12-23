using UnityEngine;
using UnityEngine.UI;
using System;


public class ChellHP : MonoBehaviour
{
    public float currentHP_Green;
    public float currentHP_Red;
    public Image GreenHP_IMG;
    public Image RedHP_IMG;
    public event Action OnDead;
    private void Awake()
    {
        GreenHP_IMG = transform.GetChild(0).GetComponent<Image>();
        RedHP_IMG = transform.GetChild(1).GetComponent<Image>();
    }
    private void Start()
    {
        UpdateHP();
    }


    private void UpdateHP()
    {
        currentHP_Green = Mathf.Clamp(currentHP_Green,0,100);
        currentHP_Red = Mathf.Clamp(currentHP_Red,0,100);
        GreenHP_IMG.fillAmount = currentHP_Green / 100;
        RedHP_IMG.fillAmount = currentHP_Red / 100;
        if (currentHP_Green <= 0)
        {
        OnDead?. Invoke();
        }
    }
    public void TakeDamage(float damage)
    {
        currentHP_Green -= damage;
        currentHP_Red += damage;
        UpdateHP();
    }
    public void HillHP(float hill)
    {
        currentHP_Green += hill;
        currentHP_Red -= hill;
        UpdateHP();
    }
}
