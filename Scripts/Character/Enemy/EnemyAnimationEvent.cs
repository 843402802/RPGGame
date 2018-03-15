using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Global;
public class EnemyAnimationEvent : MonoBehaviour {

    private EnemyAnimation _EnemyAnimation;

    private void Start()
    {
        _EnemyAnimation = GetComponentInParent<EnemyAnimation>();
    }

    /// <summary>
    /// 攻击主角（动画事件）
    /// </summary>
    public void AttackAnimationEvent()
    {
        _EnemyAnimation.AttackHeroByAnimationEvent();
    }
}
