using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    private movement movement;
    public float moveHorizotal;
   public float moveSpeed;
   public float runSpeed;
   public float changeRate;
    bool jump;
    bool run;
    public Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        movement = GetComponent<movement>();
    }
    void GetInput()
    {
        moveHorizotal = Input.GetAxis("Horizontal");
        jump = Input.GetKeyDown(KeyCode.W);
        run = Input.GetKey(KeyCode.LeftShift);
    }
    void MoveCharater()
    {
        GetInput();
        if (jump)
        {
            anim.SetTrigger("jump");
        }
        float finalSpeed;
        if (run)
        {
            finalSpeed = Mathf.Lerp(moveSpeed, runSpeed, changeRate);
            Debug.Log("runn");
            anim.SetBool("run", true);
        }
        else
        {
            anim.SetBool("run", false);
            finalSpeed = moveSpeed;
        }
          finalSpeed = moveHorizotal * Time.deltaTime * finalSpeed;
        if (moveHorizotal !=0)
        {
            movement.Move(finalSpeed, jump);
            anim.SetBool("walking", true);
        }
        else
        {
            anim.SetBool("walking", false);
        }
       
     
    }
    //public void SetAnimation(AnimationReferenceAsset referenceAsset, bool loop, float timeScale)
    //{
    //    skeletonAnimation.state.SetAnimation(0,referenceAsset,loop).TimeScale = timeScale;
    //}
    //void SetCharacterAnimationState(string state)
    //{
    //    if (state.Equals("Walking"))
    //    {
    //        SetAnimation(walking, true, 1f);
    //    }
    //}

    // Update is called once per frame
    void Update()
    {

        MoveCharater();
    }
}
