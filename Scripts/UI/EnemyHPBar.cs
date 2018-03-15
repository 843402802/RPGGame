using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Global;
using Kernal;
public class EnemyHPBar : MonoBehaviour {

    private GameObject _EnemyHPBar;
    private Camera _MainCamera;
    private Camera _UICamera;

    //血条尺寸
    public float _EnemyHPBarLength = 1.0f;
    public float _EnemyHPBarHeight = 1.0f;
    //血条位置偏移量
    public float _EnemyHPBarY = 2.0f;
    //Enemy生命数值 该数值调整血条长度
    private float _FloCurrentHP;
    private float _FloMaxHP;
    private EnemyProperty _EnemyProperty;
    private Slider _EnemyHPSlider;

	void Start () {
        _MainCamera = Camera.main.gameObject.GetComponent<Camera>();
        _UICamera = GameObject.FindGameObjectWithTag("UICamera").GetComponent<Camera>();
        _EnemyProperty = gameObject.GetComponent<EnemyProperty>();

        //加载敌人血条
        _EnemyHPBar = ResourcesMgr.GetInstance().LoadAsset("Prefabs/UI/EnemyHPBar", true);
        _EnemyHPBar.transform.parent = GameObject.FindGameObjectWithTag("BattleSceneUI").transform;
        //血条尺寸
        _EnemyHPBar.transform.localScale = new Vector3(_EnemyHPBarLength, _EnemyHPBarHeight, 0);

        if (_EnemyHPBar != null)
        {
            _EnemyHPSlider = _EnemyHPBar.GetComponent<Slider>();
        }
	}
	
	void Update () {
        //更新当前血量与最大生命值
        _FloCurrentHP = _EnemyProperty._FloCurrentHealth;
        _FloMaxHP = _EnemyProperty.MaxHealth;

        //计算血量长度
        _EnemyHPSlider.value = _FloCurrentHP / _FloMaxHP;

        //销毁该血条
        if (_EnemyHPBar&&_FloCurrentHP<=0)
        {
            Destroy(_EnemyHPBar);
        }
	}
    private void LateUpdate()
    {
        //血条三维坐标系与屏幕坐标系的转换

        if (_EnemyHPBar)
        {
            //获取目标物体屏幕坐标
            Vector3 pos = _MainCamera.WorldToScreenPoint(transform.position);
            //屏幕坐标转换为UI世界坐标
            pos = _UICamera.ScreenToWorldPoint(pos);
            //确定UI的位置 加上UI偏移量
            _EnemyHPBar.transform.position = new Vector3(pos.x, pos.y + _EnemyHPBarY, 0);
        }
    }
}
