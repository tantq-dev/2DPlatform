using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public float currentHealth;
    public float maxhealth;
    public float damage;
    public float attackCoolDown;
    private float coolDownTimer=Mathf.Infinity;
    public bool moveAround;
    public bool beAttack;
    public List<Vector3> waypoits = new List<Vector3>();
    private int current = 0;
    public float MoveSpeed = .5f;
    Vector3 currentPosition;
    private void Start()
    {
        currentHealth = maxhealth;
        currentPosition = transform.position;
        moveAround = true;
    }
    public void GetDamage(float damage)
    {
        currentHealth -= damage;
        beAttack = true;
        if (currentHealth <= 0)
        {
            Die();
        }
    }
    private void Die()
    {
        this.GetComponentInChildren<SpriteRenderer>().color = Color.gray;
        this.GetComponent<Collider2D>().enabled = true;
        StartCoroutine(wait());
    }
    IEnumerator wait()
    {
        yield return new WaitForSeconds(2);
        Destroy(gameObject);
    }
    private void Update()
    {
        if (moveAround)
        {
            MoveToWaypoints();
        }
        if (beAttack)
        {
            StopMoveAround();
        }
        
    }

    private void StopMoveAround()
    {
        moveAround = false;
    }

    void MoveToWaypoints()
    {
        if (Vector3.Distance(waypoits[current], transform.position) < 1)
        {
            current++;
            if (current >= waypoits.Count)
            {
                current = 0;
            }
        }
        transform.position = Vector3.MoveTowards(transform.position, waypoits[current], MoveSpeed * Time.deltaTime);
       

    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        for (int i = 0; i < waypoits.Count; i++)
        {
            Gizmos.DrawWireSphere(waypoits[i], .2f);
        }
    }

}
