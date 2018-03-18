using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Global;
using Kernal;
public class EnemyAnimation : MonoBehaviour {

    private EnemyProperty _EnemyProperty;                            //本身属性
    private Hero _Hero;
    private Animator _Animator;                                     //战士的动画状态机
    private bool _IsAlive = true;                                    

    void OnEnable()
    {
        //播放战士动画A部分(休闲、走路、攻击)
        StartCoroutine("PlayWarriorAnimation_A");
        //播放战士动画B部分（受伤、死亡）
        StartCoroutine("PlayWarriorAnimation_B");
        _IsAlive = true;
    }

    void OnDisable()
    {
        //播放战士动画A部分(休闲、走路、攻击)
        StopCoroutine("PlayWarriorAnimation_A");
        //播放战士动画B部分（受伤、死亡）
        StopCoroutine("PlayWarriorAnimation_B");
        //敌人的状态恢复为“站立”状态
    }

    void Start()
    {
        _EnemyProperty = this.gameObject.GetComponent<EnemyProperty>();
        _Animator = this.gameObject.GetComponentInChildren<Animator>();
        _Hero = GameObject.FindGameObjectWithTag(Tag.Player).GetComponent<Hero>();
    }

    /// <summary>
    /// 播放动画A（休闲、行走、攻击）
    /// </summary>
    /// <returns></returns>
    IEnumerator PlayWarriorAnimation_A()
    {
        yield return new WaitForEndOfFrame();
        while (true)
        {
            yield return new WaitForSeconds(0.1f);
            switch (_EnemyProperty.CurrentState)
            {
                case EnemyState.Idle:
                    _Animator.SetFloat("MoveSpeed", 0);
                    _Animator.SetBool("Attack", false);
                    break;
                case EnemyState.Walking:
                    _Animator.SetBool("Attack", false);
                    _Animator.SetFloat("MoveSpeed", 1);
                    break;
                case EnemyState.Attack:
                    _Animator.SetFloat("MoveSpeed", 0);
                    _Animator.SetBool("Attack", true);
                    break;
                default:
                    break;
            }
        }
    }
    /// <summary>
    /// 播放动画B（受伤、死亡）
    /// </summary>
    /// <returns></returns>
    IEnumerator PlayWarriorAnimation_B()
    {
        yield return new WaitForEndOfFrame();
        while (true)
        {
            yield return new WaitForSeconds(0.5f);
            switch (_EnemyProperty.CurrentState)
            {
                case EnemyState.Hurt:
                    _Animator.SetTrigger("Hurt");
                    break;
                case EnemyState.Dead:
                    if (_IsAlive)
                    {
                        _IsAlive = false;
                        _Animator.SetTrigger("Dead");
                    }
                    break;
                default:
                    break;
            }
        }
    }

    /// <summary>
    /// 攻击主角（动画事件）
    /// 子模型的AnimationEvent脚本中调用
    /// </summary>
    public void AttackHeroByAnimationEvent()
    {
        if (_Hero)
        {
            Debug.Log("AttackHeroByAnimationEvent:  " + _EnemyProperty.ATK);
            _Hero.HeroProperty.DecreaseHealthValues(_EnemyProperty.ATK);
        }
    }
}
