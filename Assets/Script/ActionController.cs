using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionController : MonoBehaviour
{
    public bool Attack;
    public bool Heal;
    public bool GetDamage;
    public float damage;
    public float health;
    public LayerMask enemyLayer;
    public GameObject AttackPoint;
    public float ASPD;
    public Animator anim;
    public float currentHealth;
    private Camera cam;
    public GameObject cameraPivot;
    public HPManager hpManager;
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = health;
        cam = Camera.main;
        hpManager.SetMaxHealth(currentHealth);

    }

    // Update is called once per frame
    void Update()
    {
        TargetCamera();
    }
    void TargetCamera()
    {
        cam.transform.position = new Vector3 (cameraPivot.transform.position.x, cameraPivot.transform.position.y,-10);

    }

   public void AttackAction()
    {
        Collider2D[] hitEnemy = Physics2D.OverlapCircleAll(AttackPoint.transform.position, 1f, enemyLayer);
      
        foreach(Collider2D enemy in hitEnemy)
        {
            Debug.Log("Hit Enemy");
            enemy.GetComponent<EnemyManager>().GetDamage(damage);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Buff")) 
        {
            string buff =collision.GetComponent<Buff>().GetBuff();
            anim.SetTrigger(buff);
        }
        if (collision.gameObject.tag == "Spike")
        {

            if (currentHealth < 0)
            {
                collision.GetComponent<Spike>().StopDealDame();
            }
            else
            {
                Debug.Log("Get dame ");
                collision.GetComponent<Spike>().DealDame();
            }
                
            
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Spike")
        {
            collision.GetComponent<Spike>().StopDealDame();
        }
    }
    public void TakeDame(float dame)
    {
        currentHealth -= dame;
        hpManager.SetHealth(currentHealth);
        if(currentHealth <= 0)
        {
            Die();
        }
    }
    void Die()
    {
        anim.SetTrigger("Death");
        this.gameObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePosition;
        
       
    }
    


}
