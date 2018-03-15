using Global;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class HeroAnimationControl : MonoBehaviour {

#region AnimationClip
    public AnimationClip Ani_Idle;                                         
    public AnimationClip Ani_Runing;

    //普通攻击三连击
    public AnimationClip Ani_NormalAttack1;                               
    public AnimationClip Ani_NormalAttack2;                               
    public AnimationClip Ani_NormalAttack3;

    public AnimationClip Ani_MagicTrickA;
    public AnimationClip Ani_MagicTrickB;

#endregion

    private Animation _AnimationHandle;                                    //动画句柄
    private HeroActionState _CurrentActionState = HeroActionState.None;    //主角的动画状态
    private NormalATKComboState _CurATKCombo = NormalATKComboState.NormalATK1;//动画连招


    /// <summary>
    /// 当前主角的动作状态(只读）
    /// </summary>
    public HeroActionState CurrentActionState
    {
        get
        {
            return _CurrentActionState;
        }
    }
    public void SetCurrentActionState(HeroActionState currentActionState)
    {
        _CurrentActionState = currentActionState;
    }

    void Start () {
        //获取子物体模型上挂载的Animation
        _AnimationHandle = GetComponentInChildren<Animation>();
        //默认动作状态
        _CurrentActionState = HeroActionState.Idle;
        //启动协程，控制主角动画状态
        StartCoroutine("ControlHeroAnimationState");
    }

    /// <summary>
    /// 主角休息，移动，普攻，技能输出等动画操作
    /// 无限循环，等待0.05s执行一次
    /// </summary>
    /// <returns></returns>
    IEnumerator ControlHeroAnimationState()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.03F);
            switch (CurrentActionState)
            {
                case HeroActionState.NormalAttack:
                    /* 攻击连招处理(自动状态转换) */
                    switch (_CurATKCombo)
                    {
                        case NormalATKComboState.NormalATK1:
                            _CurATKCombo = NormalATKComboState.NormalATK2;
                            _AnimationHandle.CrossFade(Ani_NormalAttack1.name);
                            yield return new WaitForSeconds(Ani_NormalAttack1.length);

                            _CurrentActionState = HeroActionState.Idle;
                            break;
                        case NormalATKComboState.NormalATK2:
                            _CurATKCombo = NormalATKComboState.NormalATK3;
                            _AnimationHandle.CrossFade(Ani_NormalAttack2.name);
                            yield return new WaitForSeconds(Ani_NormalAttack2.length);

                            _CurrentActionState = HeroActionState.Idle;
                            break;
                        case NormalATKComboState.NormalATK3:
                            _CurATKCombo = NormalATKComboState.NormalATK1;
                            _AnimationHandle.CrossFade(Ani_NormalAttack3.name);
                            yield return new WaitForSeconds(Ani_NormalAttack3.length);

                            _CurrentActionState = HeroActionState.Idle;
                            break;
                        default:
                            break;
                    }//Switch Combo End
                    break;
                case HeroActionState.MagicTrickA:
                    _AnimationHandle.CrossFade(Ani_MagicTrickA.name);
                    yield return new WaitForSeconds(Ani_MagicTrickA.length);

                    _CurrentActionState = HeroActionState.Idle;
                    break;
                case HeroActionState.MagicTrickB:
                    _AnimationHandle.CrossFade(Ani_MagicTrickB.name);
                    yield return new WaitForSeconds(Ani_MagicTrickB.length);

                    _CurrentActionState = HeroActionState.Idle;
                    break;
                case HeroActionState.None:
                    break;
                case HeroActionState.Idle:
                    //Idle操作即走即停，不需要等待时间
                    _AnimationHandle.CrossFade(Ani_Idle.name);
                    break;
                case HeroActionState.Runing:
                    //Run操作即走即停，不需要等待时间
                    _AnimationHandle.CrossFade(Ani_Runing.name);
                    break;
                default:
                    break;
            }//Switch CurrentActionState End
        }
    }

    
}
