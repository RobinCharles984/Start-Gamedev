using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnim : MonoBehaviour
{
    #region Variables
    private Player player;
    private Animator anim;

    #endregion
    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<Player>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        OnMove();
        OnRun();
    }

    #region Movement Methods
    public void OnMove()
    {
        if (player.direction.sqrMagnitude > 0)
        {
            if (player.isRolling)
                anim.SetTrigger("isRoll");
            else
                anim.SetInteger("transition", 1);
        }
        else
        {
            anim.SetInteger("transition", 0);
        }

        if (player.direction.x > 0)
            transform.eulerAngles = new Vector2(0, 0);
        if (player.direction.x < 0)
            transform.eulerAngles = new Vector2(0, 180);
    }

    public void OnRun()
    {
        if (player.isRunning)
        {
            anim.SetInteger("transition", 2);
        }
    }
    #endregion
}
