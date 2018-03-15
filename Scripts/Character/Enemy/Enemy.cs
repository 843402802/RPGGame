
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Global;
using Kernal;

/// <summary>
///  1.对当前状态的判断处理
///	 2.移动处理
/// </summary>
public class Enemy : MonoBehaviour {

    public float FloMoveSpeed = 3F;                                        //移动的速度
    public float FloRotatSpeed = 1F;                                       //旋转的速度
    //攻击距离必须大于两个角色碰撞器的半径之和
    public float FloAttackDistance = 1.5F;                                 //攻击距离
    public float FloCordonDistance = 5F;                                   //警戒距离
    public float FloThinkInterval = 1F;                                    //思考的间隔时间

    private GameObject _GoHero;                                            //主角
    private Transform _MyTransform;                                        //当前战士（敌人）方位
    private EnemyProperty _EnemyProperty;                                  //属性
    private CharacterController _cc;                                       //角色控制器

    void OnEnable()
    {
        //开启“思考”协程
        StartCoroutine("ThinkProcess");
        //开发“移动”协程
        StartCoroutine("MovingProcess");
    }

    void OnDisable()
    {
        //停止“思考”协程
        StopCoroutine("ThinkProcess");
        //停止“移动”协程
        StopCoroutine("MovingProcess");
    }
    void Start()
    {
        _MyTransform = this.gameObject.transform;
        _GoHero = GameObject.FindGameObjectWithTag(Tag.Player);
        _EnemyProperty = this.gameObject.GetComponent<EnemyProperty>();
        _cc = this.gameObject.GetComponent<CharacterController>();
    }
    /// <summary>
    /// 思考协程
    /// </summary>
    /// <returns></returns>
    IEnumerator ThinkProcess()
    {
        yield return new WaitForSeconds(0.5f);
        while (true)
        {
            yield return new WaitForSeconds(FloThinkInterval);
            if (_EnemyProperty && _EnemyProperty.CurrentState != EnemyState.Dead)
            {
                //得到主角的位置
                Vector3 VecHero = _GoHero.transform.position;
                //得到主角与当前（敌人）的距离
                float floDistance = Vector3.Distance(VecHero, _MyTransform.position);
                //距离判断
                if (floDistance < FloAttackDistance)
                {
                    //攻击状态
                    _EnemyProperty.CurrentState = EnemyState.Attack;
                }
                else if (floDistance < FloCordonDistance)
                {
                    //警戒（追击）
                    _EnemyProperty.CurrentState = EnemyState.Walking;
                }
                else
                {
                    //休闲
                    _EnemyProperty.CurrentState = EnemyState.Idle;
                }
            }
        }
    }
    /// <summary>
    /// 移动协程
    /// </summary>
    /// <returns></returns>
    IEnumerator MovingProcess()
    {
        yield return new WaitForSeconds(1.0f);
        while (true)
        {
            yield return new WaitForSeconds(0.02f);
            if (_EnemyProperty && _EnemyProperty.CurrentState != EnemyState.Dead)
            {
                //移动
                switch (_EnemyProperty.CurrentState)
                {
                    case EnemyState.Walking:
                        //面向主角
                        FaceToHero();
                        //英雄方位-当前敌人方位
                        Vector3 vec = Vector3.ClampMagnitude((_GoHero.transform.position - _MyTransform.position), FloMoveSpeed * Time.deltaTime);
                        _cc.Move(vec);
                        break;
                    case EnemyState.Hurt:
                        //面向主角
                        FaceToHero();
                        //敌人受伤后退移动
                        Vector3 vect = -transform.forward * FloMoveSpeed / 2 * Time.deltaTime;
                        _cc.Move(vect);
                        break;
                    default:
                        break;
                }
            }
        }
    }

    /// <summary>
    /// 面向主角
    /// </summary>
    private void FaceToHero()
    {
        UnityHelper.GetInstance().FaceToGoal(_MyTransform, _GoHero.transform, FloRotatSpeed);
    }
}
