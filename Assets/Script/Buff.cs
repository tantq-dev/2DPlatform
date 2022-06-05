using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buff : MonoBehaviour
{
    public string type;
    public ActionController controller;
    public float point = 10;


    void Start()
    {
        
    }
   public string GetBuff()
    {
        if(type == "ASPD")
        {
            AttackSpeedBuff();
            Destroy(gameObject);
            return "ASPDBuff";
        }
        if (type == "HP")
        {
            Destroy(gameObject);
            HealthBuff();
            return "HealthBuff";
        }

        return null;
    }

    private void HealthBuff()
    {
       
        controller.currentHealth += point;
    }

    private void AttackSpeedBuff()
    {
        controller.ASPD += point;
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
