using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    public float ASPD = 1f;
    [SerializeField]
    private float coolDownTimer = Mathf.Infinity;
    private bool canAttack;
    private int state = 0;
    private bool firstTimeAttack = true;
    float exitTime = 2;
    public Animator animator;
   public ActionController controller;



    private void Start()
    {
        coolDownTimer = ASPD;
        canAttack = true;
    }
    public void Combo()
    {
        if ( state == 0)
        {

            Debug.Log("Attack 0");
            animator.SetTrigger("Attack");
            animator.SetFloat("Blend",state);
            controller.AttackAction();
            state = 1;
            coolDownTimer = 0;
        }
        else if (state == 1)
        {

            Debug.Log("Attack State 1");
            animator.SetTrigger("Attack");
            animator.SetFloat("Blend", state);
            controller.AttackAction();
            state = 0;
            coolDownTimer = 0;

        }
    }
    private void Update()
    {
        coolDownTimer += Time.deltaTime;
        if (Input.GetKeyUp(KeyCode.Space))
        {
            {
                if (coolDownTimer > ASPD && coolDownTimer < exitTime)
                {
                    Combo();
                }
                else if(coolDownTimer > exitTime)
                {
                    state= 0;
                    coolDownTimer = ASPD;
                    Combo();
                }
            }


        }
    }
}
