using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Global;
using Kernal;

public class HeroMovingControlByET : MonoBehaviour {

    public float FloHeroMovingSpeed = 5F;                                  //英雄移动的速度
    public float FloHeroAttackMoveingSpeed = 10F;                          //英雄攻击移动速度

    private CharacterController _cc;
    private float _FloGravity = 1F;                                        //角色控制器模拟重力

    private Hero _Hero;

    void Start()
    {
        _cc = GetComponent<CharacterController>();
        _Hero = GetComponent<Hero>();

        StartCoroutine("AttackByMove");
    }

    #region 事件注册
    /// <summary>
    /// 游戏对象的启用
    /// </summary>
    void OnEnable()
    {
        EasyJoystick.On_JoystickMove += OnJoystickMove;
        EasyJoystick.On_JoystickMoveEnd += OnJoystickMoveEnd;
    }
    /// <summary>
    /// 游戏对象的禁用
    /// </summary>
    public void OnDisable()
    {
        EasyJoystick.On_JoystickMove -= OnJoystickMove;
        EasyJoystick.On_JoystickMoveEnd -= OnJoystickMoveEnd;
    }
    /// <summary>
    /// 游戏对象的销毁
    /// </summary>
    public void OnDestroy()
    {
        EasyJoystick.On_JoystickMove -= OnJoystickMove;
        EasyJoystick.On_JoystickMoveEnd -= OnJoystickMoveEnd;
    }
    #endregion

    /// <summary>
    /// 攻击移动
    /// </summary>
    /// <returns></returns>
    IEnumerator AttackByMove()
    {
        yield return new WaitForSeconds(0.3f);
        while (true)
        {
            yield return new WaitForSeconds(0.2f);
            if (_Hero.HeroAnimationControl.CurrentActionState == HeroActionState.NormalAttack)
            {
                Vector3 vec = transform.forward * FloHeroAttackMoveingSpeed * Time.deltaTime;
                _cc.Move(vec);
                Debug.Log("attackMove");
            }
        }
    }

    /// <summary>
    /// 移动摇杆中 
    /// </summary>
    /// <param name="move"></param>
    void OnJoystickMove(MovingJoystick move)
    {
        if (move.joystickName != GlobalParameter.JOYSTICK_NAME)
        {
            return;
        }

        //获取摇杆中心偏移的坐标  
        float joyPositionX = move.joystickAxis.x;
        float joyPositionY = move.joystickAxis.y;

        if (joyPositionY != 0 || joyPositionX != 0)
        {
            //设置角色的朝向（朝向当前坐标+摇杆偏移量)
            if (_Hero.HeroAnimationControl.CurrentActionState != HeroActionState.MagicTrickB)
            {
                transform.LookAt(new Vector3(transform.position.x + joyPositionX, transform.position.y, transform.position.z + joyPositionY));
            }
            //移动玩家的位置（按朝向位置移动）  
            Vector3 movement = transform.forward * Time.deltaTime * FloHeroMovingSpeed;
            //增加模拟重力
            movement.y -= _FloGravity;
            //角色控制器
            if (_Hero.HeroAnimationControl.CurrentActionState == HeroActionState.Idle ||
                _Hero.HeroAnimationControl.CurrentActionState == HeroActionState.Runing)
            {
                _cc.Move(movement);

                //播放奔跑动画
                if (UnityHelper.GetInstance().GetSmallTime(0.1F))
                {
                    _Hero.HeroAnimationControl.SetCurrentActionState(HeroActionState.Runing);
                }
            }
        }
    }

    /// <summary>
    /// 移动摇杆结束
    /// </summary>
    /// <param name="move"></param>
    void OnJoystickMoveEnd(MovingJoystick move)
    {
        //停止时，角色恢复idle  
        if (move.joystickName == GlobalParameter.JOYSTICK_NAME)
        {
            if (_Hero.HeroAnimationControl.CurrentActionState == HeroActionState.Idle ||
                _Hero.HeroAnimationControl.CurrentActionState == HeroActionState.Runing)
            {
                _Hero.HeroAnimationControl.SetCurrentActionState(HeroActionState.Idle);
            }
        }
    }
    //#endif
}
