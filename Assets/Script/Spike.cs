using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spike : MonoBehaviour
{
    public ActionController controller;
    public float damage;
    public float attackCoolDown;
    private float coolDownTimer = Mathf.Infinity;
    bool isDealingDame =false;
    public Animator animator;

    void Start()
    {
      
    }

    public void DealDame()
    {
       isDealingDame = true;
    }
    public void StopDealDame()
    {
       isDealingDame = false;
    }
    void DealSpikeDame(float dame)
    {
       if (controller.currentHealth <= 0)
        {
            isDealingDame = false;
        }
        else
        {
            controller.TakeDame(dame);
            animator.SetTrigger("BeHit");
            coolDownTimer = 0;
        }
        
    }
    // Update is called once per frame
    void Update()
    {
        if (isDealingDame)
        {
            coolDownTimer += Time.deltaTime;
            Debug.Log(coolDownTimer);
            if (coolDownTimer > attackCoolDown)
            {
                DealSpikeDame(damage);
                
            }
        }
       
       
    }
}
