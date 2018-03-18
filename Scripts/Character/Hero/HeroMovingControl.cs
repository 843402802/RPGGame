using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Global;
using Kernal;

public class HeroMovingControl : MonoBehaviour {

    public float FloHeroMovingSpeed = 5F;                                  //英雄移动的速度
    public float FloHeroAttackMoveingSpeed = 10F;
    private float _FloGravity = 1F;                                        //角色控制器模拟重力

    private CharacterController _cc;                                       //角色控制器

    private Hero _Hero;

    void Start()
    {
        _cc = GetComponent<CharacterController>();
        _Hero = GetComponent<Hero>();

        StartCoroutine("AttackByMove");
    }

    void Update()
    {
        ControlMoving();
    }

    /// <summary>
    /// 控制主角移动
    /// </summary>
    void ControlMoving()
    {
        //点击键盘按键，获取水平与垂直偏移量
        float floMovingXPos = Input.GetAxis("Horizontal");//从-1到1偏移量
        float floMovingYPos = Input.GetAxis("Vertical");

        if (floMovingXPos != 0 || floMovingYPos != 0)
        {
            //设置角色的朝向（朝向当前坐标+摇杆偏移量）
            if(_Hero.HeroAnimationControl.CurrentActionState!= HeroActionState.MagicTrickB)
            {
                transform.LookAt(new Vector3(transform.position.x + floMovingXPos, transform.position.y, transform.position.z + floMovingYPos));
            }
            //移动玩家的位置（按朝向位置移动）  
            Vector3 movement = transform.forward * Time.deltaTime * FloHeroMovingSpeed;
            //增加模拟重力
            movement.y -= _FloGravity;
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
        else
        {
            if (UnityHelper.GetInstance().GetSmallTime(0.1F))
            {
                _Hero.HeroAnimationControl.SetCurrentActionState(HeroActionState.Idle);
            }
        }
    }


    /// <summary>
    /// 攻击过程中保持移动
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
}
