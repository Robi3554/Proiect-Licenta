using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] 
    protected WeaponData weaponData;

    protected Animator anim;

    protected PlayerAttackState state;

    protected Core core;

    protected Player player;

    protected int attackCounter;

    protected virtual void Awake()
    {
        anim = GetComponent<Animator>();

        player = GetComponentInParent<Player>();

        gameObject.SetActive(false);
    }

    public virtual void EnterWeapon()
    {
        gameObject.SetActive(true);

        if(attackCounter >= weaponData.amountOfAttacks)
        {
            attackCounter = 0;
        }

        anim.SetBool("attack", true);

        anim.SetInteger("attackCounter", attackCounter);
    }

    public virtual void ExitWeapon()
    {
        anim.SetBool("attack", false);

        attackCounter++;

        gameObject.SetActive(false);
    }

    #region Animation Triggers

    public virtual void AnimationFinishTrigger()
    {
        state.AnimationFinishTrigger();
    }

    public virtual void AnimationStartMoveTrigger()
    {
        state.SetPlayerVelocity(weaponData.moveSpeed[attackCounter]);
    }

    public virtual void AnimationStopMoveTrigger()
    {
        state.SetPlayerVelocity(0);
    }

    public virtual void AnimationTurnOffFlipTrigger()
    {
        state.SetFlipCheck(false);
    }

    public virtual void AnimationTurnOnFlipTrigger()
    {
        state.SetFlipCheck(true);
    }

    public virtual void AnimationActionTrigger()
    {

    }

    #endregion

    public void InitializeWeapon(PlayerAttackState state, Core core)
    {
        this.state = state;
        this.core = core;
    }
}
