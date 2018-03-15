using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Global;
using Kernal;
public class ShowHeroInfo : MonoBehaviour {

    //玩家信息
    public Text TxtPlayerNameByDetailPanel;                                 //玩家名字
    public Text TxtCurLevel;                                                //当前等级

    public Text TxtKillNumber;                                              //杀敌数
    public Text TxtGold;                                                    //金币
    public Text TxtDiamonds;                                                //金币

    public Text TxtHP_Cur;
    public Text TxtHP_Max;
    public Slider SliHP;

    public Text TxtMP_Cur;
    public Text TxtMP_Max;
    public Slider SliMP;

    public 
    void Awake()
    {
        //核心数值事件注册
        HeroProperty.evePlayerKernal += DisplayHP;
        HeroProperty.evePlayerKernal += DisplayMaxHP;
        HeroProperty.evePlayerKernal += DisplayMP;
        HeroProperty.evePlayerKernal += DisplayMaxMP;


        //扩展数值事件注册
        HeroProperty.evePlayerKernal += DisplayKillNumber;
        HeroProperty.evePlayerKernal += DisplayLevel;
        HeroProperty.evePlayerKernal += DisplayGold;
        HeroProperty.evePlayerKernal += DisplayDiamonds;
    }
    #region 事件注册方法
    private void DisplayHP(KeyValuesUpdate kv)
    {
        if (kv.Key.Equals("Health") && TxtHP_Cur)
        {
            TxtHP_Cur.text = kv.Value.ToString();

            SliHP.value = (float)kv.Value;
        }
    }
    private void DisplayMaxHP(KeyValuesUpdate kv)
    {
        if (kv.Key.Equals("MaxHealth") && TxtHP_Max)
        {
            TxtHP_Max.text = kv.Value.ToString();

            //滑动条处理
            SliHP.maxValue = (float)kv.Value;
            SliHP.minValue = 0;
        }
    }
    private void DisplayMP(KeyValuesUpdate kv)
    {
        if (kv.Key.Equals("Magic")&& TxtMP_Cur)
        {
            TxtMP_Cur.text = kv.Value.ToString();

            SliMP.value = (float)kv.Value;
        }
    }
    private void DisplayMaxMP(KeyValuesUpdate kv)
    {
        if (kv.Key.Equals("MaxMagic") && TxtMP_Max)
        {
            TxtMP_Max.text = kv.Value.ToString();

            //滑动条处理
            SliMP.maxValue = (float)kv.Value;
            SliMP.minValue = 0;
        }
    }


    private void DisplayKillNumber(KeyValuesUpdate kv)
    {
        if (kv.Key.Equals("KillNumber") && TxtKillNumber)
        {
            TxtKillNumber.text = kv.Value.ToString();
        }
    }
    private void DisplayLevel(KeyValuesUpdate kv)
    {
        if (kv.Key.Equals("Level")  && TxtCurLevel)
        {
            TxtCurLevel.text = kv.Value.ToString();
        }
    }
    private void DisplayGold(KeyValuesUpdate kv)
    {
        if (kv.Key.Equals("Gold") && TxtGold)
        {
            TxtGold.text = kv.Value.ToString();
        }
    }
    private void DisplayDiamonds(KeyValuesUpdate kv)
    {
        if (kv.Key.Equals("Diamonds") && TxtDiamonds)
        {
            TxtDiamonds.text = kv.Value.ToString();
        }
    }

    #endregion
}
