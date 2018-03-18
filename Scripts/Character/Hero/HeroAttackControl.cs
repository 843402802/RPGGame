using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Global;
using Kernal;

public class HeroAttackControl : MonoBehaviour {

    public float FloMinAttackDistance = 5;                                 //最小攻击距离（关注）
    public float FloHeroRotationSpeed = 1F;                                //主角旋转速率
    public float FloRealAttackArea = 2F;                                   //主角实际有效攻击距离

    //关于大招攻击参数定义
    public float FloAttackAreaByMagicA = 4F;                               //大招A的攻击范围
    public float FloAttackAreaByMagicB = 8F;                               //大招B的攻击范围
    public int IntAttackPowerMultipleByMagicA = 3;                         //大招A的攻击力倍率
    public int IntAttackPowerMultipleByMagicB = 5;                        //大招B的攻击力倍率

    private List<GameObject> _ListEnemys;                                  //敌人集合
    private Transform _TraNearestEnemy;                                    //最近敌人方位
    private float _FloMaxDistance = 10;                                    //敌我最大距离（放入“敌人数组”）

    private Hero _Hero;

    void Awake()
    {
        //事件注册: 主角攻击输入
        PlayerInputControl.evePlayerControl += ResponseNormalAttack;
        PlayerInputControl.evePlayerControl += ResponseMagicTrickA;
        PlayerInputControl.evePlayerControl += ResponseMagicTrickB;
    }

    void Start()
    {
        _ListEnemys = new List<GameObject>();
        StartCoroutine("RecordNearbyEnemysToArray");
        _Hero = GetComponent<Hero>();
    }

    #region 响应攻击输入  手机端控件操作
    /// <summary>
    /// 响应普通攻击
    /// </summary>
    /// <param name="controlType"></param>
    public void ResponseNormalAttack(string controlType)
    {
        if (controlType == "NormalAttack")
        {
            //播放攻击动画
            _Hero.HeroAnimationControl.SetCurrentActionState(HeroActionState.NormalAttack);
        }
    }

    /// <summary>
    /// 响应大招A
    /// </summary>
    public void ResponseMagicTrickA(string controlType)
    {
        if (controlType == "MagicTrickA")
        {
            //播放攻击动画
            _Hero.HeroAnimationControl.SetCurrentActionState(HeroActionState.MagicTrickA);
        }
    }

    /// <summary>
    /// 响应大招B
    /// </summary>
    public void ResponseMagicTrickB(string controlType)
    {
        if (controlType == "MagicTrickB")
        {
            //播放攻击动画
            _Hero.HeroAnimationControl.SetCurrentActionState(HeroActionState.MagicTrickB);
        }
    }
    #endregion

    
    //普攻
    public void AttackEnemyByNormal()
    {
        AttackEnemy(_ListEnemys, _TraNearestEnemy, FloRealAttackArea, 1, true);
    }
    //A大招
    public void AttackEnemyByMagicA()
    {
        AttackEnemy(_ListEnemys, _TraNearestEnemy, FloAttackAreaByMagicA, IntAttackPowerMultipleByMagicA, false); ;
    }
    //B大招
    public void AttackEnemyByMagicB()
    {
        AttackEnemy(_ListEnemys, _TraNearestEnemy, FloAttackAreaByMagicB, IntAttackPowerMultipleByMagicB);
    }
    /// <summary>
    /// 攻击敌人
    /// </summary>
    /// <param name="attackArea">攻击范围</param>
    /// <param name="attackPowerMultiple">攻击力度（倍率）</param>
    /// <param name="isDirection">攻击是否有方向性</param>
    private void AttackEnemy(List<GameObject> lisEnemys, Transform traNearestEnemy, float attackArea, int attackPowerMultiple, bool isDirection = true)
    {
        //Debug.Log("AttackEnemy");
        //参数检查
        if (lisEnemys == null || lisEnemys.Count <= 0)
        {
            traNearestEnemy = null;
            return;
        }

        foreach (GameObject enemyItem in lisEnemys)
        {
            if (enemyItem && enemyItem.GetComponent<EnemyProperty>() && enemyItem.GetComponent<EnemyProperty>().CurrentState != EnemyState.Dead)
            {
                //敌我距离
                float floDistance = Vector3.Distance(gameObject.transform.position, enemyItem.transform.position);
                //攻击具有方向性
                if (isDirection)
                {
                    //定义“主角与敌人” 的方向
                    Vector3 dir = (enemyItem.transform.position - gameObject.transform.position).normalized;
                    //定义“主角与敌人”的夹角(用向量的“点乘”进行计算)
                    float floDirection = Vector3.Dot(dir, gameObject.transform.forward);
                    //如果主角与敌人在同一个方向，且在有效攻击范围内，则对敌人做伤害处理
                    if (floDirection > 0 && floDistance <= attackArea)
                    {
                        //TODO 当前攻击力与技能伤害
                        enemyItem.SendMessage("OnHurt",_Hero.HeroProperty.GetCurrentATK());
                    }
                }
                //攻击无方向性
                else
                {
                    if (floDistance <= attackArea)
                    {
                        //TODO 当前攻击力与技能伤害
                        enemyItem.SendMessage("OnHurt", _Hero.HeroProperty.GetCurrentATK());
                    }
                }
            }
        }
    }

   #region 攻击目标判定
    /// <summary>
    /// 把附近敌人放入“敌人数组”
    /// </summary>
    IEnumerator RecordNearbyEnemysToArray()
    {
        while (true)
        {
            yield return new WaitForSeconds(1.0f);
            GetEnemysToArray();
            GetNearestEnemy();
        }
    }

    /// <summary>
    /// 得到所有(活着的)敌人，放入“敌人集合”
    /// </summary>
    private void GetEnemysToArray()
    {
        GameObject[] goEnemys = GameObject.FindGameObjectsWithTag(Tag.Enemy);
        _ListEnemys.Clear();
        foreach (GameObject goItem in goEnemys)
        {
            EnemyProperty enemy = goItem.GetComponent<EnemyProperty>();
            if (enemy && enemy.CurrentState != EnemyState.Dead)
            {
                _ListEnemys.Add(goItem);
            }
        }
    }

    /// <summary>
    /// 判断“敌人集合”，找最近敌人
    /// </summary>
    private void GetNearestEnemy()
    {
        if (_ListEnemys != null && _ListEnemys.Count >= 1)
        {
            foreach (GameObject goEnemy in _ListEnemys)
            {
                float floDistance = Vector3.Distance(this.gameObject.transform.position, goEnemy.transform.position);
                if (floDistance < _FloMaxDistance)
                {
                    _FloMaxDistance = floDistance;
                    _TraNearestEnemy = goEnemy.transform;
                }
            }
        }
    }
    #endregion
}
