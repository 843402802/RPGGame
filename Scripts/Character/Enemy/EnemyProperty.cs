using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Global;
using Kernal;

public class EnemyProperty : MonoBehaviour {

    public int HeroExpenrence = 0;                                         //英雄的经验数值
    public int ATK = 0;                                                    //攻击力
    public int DEF = 0;                                                    //防御力
    public int MaxHealth = 0;                                              //最大的生命数值

    public float _FloCurrentHealth = 0;                                   //当前生命数值 
    private EnemyState _CurrentState = EnemyState.Idle;                    //当前状态

    private Hero _Hero;

    /// <summary>
    /// 属性： 当前状态
    /// </summary>
    public EnemyState CurrentState
    {
        get { return _CurrentState; }
        set { _CurrentState = value; }
    }
    private void Start()
    {
        _Hero = GameObject.FindGameObjectWithTag(Tag.Player).GetComponent<Hero>();
    }
    void OnEnable()
    {
        //判断是否生命存活
        StartCoroutine("CheckLifeContinue");
    }

    void OnDisable()
    {
        //判断是否生命存活
        StopCoroutine("CheckLifeContinue");
    }
    /// <summary>
    /// 伤害处理
    /// </summary>
    /// <param name="hurtValue"></param>
    public void OnHurt(int hurtValue)
    {
        Debug.Log("敌人受到伤害");
        int hurtValues = 0;

        //受伤状态
        _CurrentState = EnemyState.Hurt;
        hurtValues = Mathf.Abs(hurtValue);
        if (hurtValues > 0)
        {
            _FloCurrentHealth -= hurtValues;
        }
    }
    /// <summary>
    /// 判断是否生命存活
    /// </summary>
    /// <returns></returns>
    IEnumerator CheckLifeContinue()
    {
        while (true)
        {
            yield return new WaitForSeconds(1.0f);

            if (_FloCurrentHealth <= 0)
            {
                //关于英雄增加相关数值。
                //增加经验值
                _Hero.HeroProperty.AddExp(HeroExpenrence);
                //增加杀敌数量    
                if (_CurrentState != EnemyState.Dead)
                {
                    _Hero.HeroProperty.AddKillNumber();
                }
                //死亡状态
                _CurrentState = EnemyState.Dead;
                //销毁对象
                Destroy(this.gameObject, 5F);//5秒死亡延迟
            }
        }
    }
}
