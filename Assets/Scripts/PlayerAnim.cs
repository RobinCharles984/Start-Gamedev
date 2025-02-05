using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnim : MonoBehaviour
{
    #region Variables
    [Header("Components")]
    private Animator anim;
    private Player player;
    #endregion
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        player = GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        OnMoveAnim();
        MirrorPlayer();
    }

    #region Movement
    void OnMoveAnim()
    {
        if (player.direction.sqrMagnitude > 0)
        {
            if (player.isRolling)
                OnRollAnim(); //Rolling
            if (player.isRunning)
                OnRunAnim(); //Running
            else
                anim.SetInteger("transition", 1);
        }
        else
            anim.SetInteger("transition", 0);
    }

    void OnRunAnim()
    {
        anim.SetInteger("transition", 2);
    }

    void OnRollAnim()
    {
        anim.SetInteger("transition", 3);
    }

    void MirrorPlayer()
    {
        if (player.direction.x > 0)
            transform.eulerAngles = new Vector2(0, 0);
        if (player.direction.x < 0)
            transform.eulerAngles = new Vector2(0, 180);
    }
    #endregion
}
