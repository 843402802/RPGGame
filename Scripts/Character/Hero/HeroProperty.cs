using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Global;

public class HeroProperty : MonoBehaviour {

    public static event del_PlayerData evePlayerData;//玩家核心数值

    //玩家核心数值
    public float _FloHP_Cur = 100F;                                         //当前生命
    public float _FloHP_Max = 100F;                                         //最大生命
    public float _FloMP_Cur = 100F;                                         //当前魔法
    public float _FloMP_Max = 100F;                                         //最大魔法
    public float _FloATK_Cur = 10F;                                         //当前攻击
    public float _FloATK_Max = 10F;                                         //当前攻击
    public float _FloDEF_Cur = 5F;                                          //当前防御
    public float _FloDEF_Max = 5F;                                          //当前防御
    public float _FloDEX_Cur = 45F;                                         //当前敏捷
    public float _FloDEX_Max = 50F;                                         //当前敏捷

    public float _FloATKByProp = 0F;                                        //道具攻击力
    public float _FloDEFByProp = 0F;                                        //道具防御力
    public float _FloDEXByProp = 0F;                                        //道具敏捷度

    //玩家扩展数值
    public int _IntEXP = 0;                                                 //当前经验
    public int _IntLevel = 0;                                               //当前等级
    public int _IntKillNum = 0;                                             //当前杀敌
    public int _IntGold = 0;                                                //当前金币
    public int _IntDiamonds = 0;                                            //当前钻石

    public const int ENEMY_MIN_ATK = 1;//敌人最低攻击力

    private Hero _Hero;

    private void Start()
    {
        _Hero = GetComponent<Hero>();
    }
    #region 角色状态属性
    public float Health
    {
        get
        {
            return _FloHP_Cur;
        }

        set
        {
            _FloHP_Cur = value;
            //事件调用
            if (evePlayerData != null)
            {
                KeyValuesUpdate kv = new KeyValuesUpdate("Health", Health);
                evePlayerData(kv);
            }
        }
    }

    public float Magic
    {
        get
        {
            return _FloMP_Cur;
        }

        set
        {
            _FloMP_Cur = value;

            //事件调用
            if (evePlayerData != null)
            {
                KeyValuesUpdate kv = new KeyValuesUpdate("Magic", Magic);
                evePlayerData(kv);
            }
        }
    }

    public float Attack
    {
        get
        {
            return _FloATK_Cur;
        }

        set
        {
            _FloATK_Cur = value;

            //事件调用
            if (evePlayerData != null)
            {
                KeyValuesUpdate kv = new KeyValuesUpdate("Attack", Attack);
                evePlayerData(kv);
            }
        }
    }

    public float Defence
    {
        get
        {
            return _FloDEF_Cur;
        }

        set
        {
            _FloDEF_Cur = value;
            //事件调用
            if (evePlayerData != null)
            {
                KeyValuesUpdate kv = new KeyValuesUpdate("Defence", Defence);
                evePlayerData(kv);
            }
        }
    }

    public float Dexterity
    {
        get
        {
            return _FloDEF_Cur;
        }

        set
        {
            _FloDEF_Cur = value;

            //事件调用
            if (evePlayerData != null)
            {
                KeyValuesUpdate kv = new KeyValuesUpdate("Dexterity", Dexterity);
                evePlayerData(kv);
            }
        }
    }

    public float MaxHealth
    {
        get
        {
            return _FloHP_Max;
        }

        set
        {
            _FloHP_Max = value;
            //事件调用
            if (evePlayerData != null)
            {
                KeyValuesUpdate kv = new KeyValuesUpdate("MaxHealth", MaxHealth);
                evePlayerData(kv);
            }
        }
    }

    public float MaxAttack
    {
        get
        {
            return _FloATK_Max;
        }

        set
        {
            _FloATK_Max = value;

            //事件调用
            if (evePlayerData != null)
            {
                KeyValuesUpdate kv = new KeyValuesUpdate("MaxAttack", MaxAttack);
                evePlayerData(kv);
            }
        }
    }

    public float MaxMagic
    {
        get
        {
            return _FloMP_Max;
        }

        set
        {
            _FloMP_Max = value;

            //事件调用
            if (evePlayerData != null)
            {
                KeyValuesUpdate kv = new KeyValuesUpdate("MaxMagic", MaxMagic);
                evePlayerData(kv);
            }
        }
    }

    public float MaxDefence
    {
        get
        {
            return _FloDEF_Max;
        }

        set
        {
            _FloDEF_Max = value;
            //事件调用
            if (evePlayerData != null)
            {
                KeyValuesUpdate kv = new KeyValuesUpdate("MaxDefence", MaxDefence);
                evePlayerData(kv);
            }
        }
    }

    public float MaxDexterity
    {
        get
        {
            return _FloDEX_Max;
        }

        set
        {
            _FloDEX_Max = value;
            //事件调用
            if (evePlayerData != null)
            {
                KeyValuesUpdate kv = new KeyValuesUpdate("MaxDexterity", MaxDexterity);
                evePlayerData(kv);
            }
        }
    }

    public float AttackByProp
    {
        get
        {
            return _FloATKByProp;
        }

        set
        {
            _FloATKByProp = value;
            //事件调用
            if (evePlayerData != null)
            {
                KeyValuesUpdate kv = new KeyValuesUpdate("AttackByProp", AttackByProp);
                evePlayerData(kv);
            }
        }
    }

    public float DefenceByProp
    {
        get
        {
            return _FloDEXByProp;
        }

        set
        {
            _FloDEXByProp = value;
            //事件调用
            if (evePlayerData != null)
            {
                KeyValuesUpdate kv = new KeyValuesUpdate("DefenceByProp", DefenceByProp);
                evePlayerData(kv);
            }
        }
    }

    public float DexterityByProp
    {
        get
        {
            return _FloDEXByProp;
        }

        set
        {
            _FloDEXByProp = value;
            //事件调用
            if (evePlayerData != null)
            {
                KeyValuesUpdate kv = new KeyValuesUpdate("DexterityByProp", DexterityByProp);
                evePlayerData(kv);
            }
        }
    }
    #endregion
    #region 角色状态属性策略
    #region 生命数值操作
    /// <summary>
    /// 减少生命数值
    /// 公式：_Health = _Health-（敌人攻击力-主角防御力-主角武器防御力）
    /// </summary>
    /// <param name="enemyAttackValue">敌人攻击力</param>
    public void DecreaseHealthValues(float enemyAttackValue)
    {
        float enemyReallyATK = 0F;
        enemyReallyATK = enemyAttackValue - Defence - DefenceByProp;

        if (enemyReallyATK > 0)
        {
            Health -= enemyReallyATK;
        }
        else
        {
            Health -= ENEMY_MIN_ATK;
        }
    }
    /// <summary>
    /// 增加生命数值
    /// </summary>
    /// <param name="healthValue"></param>
    public void IncreaseHealthValues(float healthValue)
    {
        float floReallyIncreseHealth = 0F;
        floReallyIncreseHealth = Health + healthValue;
        if (floReallyIncreseHealth < MaxHealth)
        {
            Health += healthValue;
        }
        else
        {
            Health = MaxHealth;
        }
    }
    /// <summary>
    /// 得到生命数值
    /// </summary>
    /// <returns></returns>
    public float GetCurrentHealth()
    {
        return Health;
    }

    /// <summary>
    /// 增加最大生命数值
    /// </summary>
    /// <param name="increaseHealth">增量</param>
    public void IncreaseMaxHealth(float increaseHealth)
    {
        MaxHealth += Mathf.Abs(increaseHealth);
    }
    /// <summary>
    /// 得到最大生命数值
    /// </summary>
    /// <returns></returns>
    public float GetMaxHealth()
    {
        return MaxHealth;
    }
    #endregion

    #region 魔法数值操作
    /// <summary>
    /// 减少魔法数值
    /// 公式：_Magic = _Magic - ( 释放一次“特定魔法”的损耗 )
    /// </summary>
    /// <param name="magicValue">魔法数值损耗</param>
    public void DecreaseMagicValues(float magicValue)
    {
        float reallyMagicValuesResult = 0F;//实际的剩余魔法数值
        reallyMagicValuesResult = Magic - magicValue;

        if (reallyMagicValuesResult > 0)
        {
            Magic -= Mathf.Abs(magicValue);
        }
        else
        {
            Magic = 0;
        }
    }
    /// <summary>
    /// 增加魔法数值
    /// </summary>
    /// <param name="MagicValue"></param>
    public void IncreaseMagicValues(float MagicValue)
    {
        float floReallyIncreseMagic = 0F;

        floReallyIncreseMagic = Magic + MagicValue;
        if (floReallyIncreseMagic < MaxMagic)
        {
            Magic += MagicValue;
        }
        else
        {
            Magic = MaxMagic;
        }
    }
    public float GetCurrentMagic()
    {
        return Magic;
    }
    /// <summary>
    /// 增加最大魔法值
    /// </summary>
    /// <param name="increaseMagic"></param>
    public void IncreaseMaxMagic(float increaseMagic)
    {
        MaxMagic += Mathf.Abs(increaseMagic);
    }
    /// <summary>
    /// 得到最大魔法值
    /// </summary>
    /// <returns></returns>
    public float GetMaxMagic()
    {
        return MaxMagic;
    }
    #endregion

    #region 攻击力数值操作
    /// <summary>
    /// 更新攻击力（典型应用场景：主角健康值改变；取得新武器）
    /// 公式：_AttackForce=MaxATK+[“武器攻击力”]
    /// </summary>
    /// <param name="newWeaponValues">新武器数值</param>
    public void UpdateATKValues(float newWeaponValues = 0)
    {
        float reallyATKValues = 0F;//实际的攻击数值

        if (newWeaponValues == 0)//没有获取新的武器道具
        {
            reallyATKValues = MaxAttack + AttackByProp;
        }
        else if (newWeaponValues > 0)//取得武器道具
        {
            AttackByProp = newWeaponValues;
            reallyATKValues = MaxAttack + AttackByProp;
        }
        //数值有效性验证
        if (reallyATKValues > MaxAttack)
        {
            Attack = MaxAttack;
        }
        else
        {
            Attack = reallyATKValues;
        }
    }
    /// <summary>
    /// 得到当前攻击力
    /// </summary>
    /// <returns></returns>
    public float GetCurrentATK()
    {
        return Attack;
    }
    /// <summary>
    /// 增加最大攻击力
    /// </summary>
    /// <param name="increaseATK"></param>
    public void IncreaseMaxATK(float increaseATK)
    {
        MaxAttack += Mathf.Abs(increaseATK);
    }
    /// <summary>
    /// 得到最大攻击力
    /// </summary>
    /// <returns></returns>
    public float GetMaxATK()
    {
        return MaxAttack;
    }
    #endregion

    #region 防御力数值操作
    /// <summary>
    /// 更新防御力（典型应用场景：主角健康值改变；取得新武器）
    /// 公式：_Defence=MaxDEF+[武器防御力]
    /// </summary>
    /// <param name="newWeaponDEFValues">新防御武器数值</param>
    public void UpdateDEFValues(float newWeaponDEFValues = 0)
    {
        float reallyDEFValues = 0F;//实际的攻击数值

        if (newWeaponDEFValues == 0)//没有获取新的武器道具
        {
            reallyDEFValues = MaxDefence + DefenceByProp;
        }
        else if (newWeaponDEFValues > 0)//取得武器道具
        {
            DefenceByProp = newWeaponDEFValues;
            reallyDEFValues = MaxDefence + DefenceByProp;
        }
        //数值有效性验证
        if (reallyDEFValues > MaxDefence)
        {
            Defence = MaxDefence;
        }
        else
        {
            Defence = reallyDEFValues;
        }
    }
    /// <summary>
    /// 得到当前防御力
    /// </summary>
    /// <returns></returns>
    public float GetCurrentDEF()
    {
        return Defence;
    }
    /// <summary>
    /// 增加最大防御力
    /// </summary>
    /// <param name="increaseDEF"></param>
    public void IncreaseMaxDEF(float increaseDEF)
    {
        MaxDefence += Mathf.Abs(increaseDEF);
    }
    /// <summary>
    /// 得到最大防御力
    /// </summary>
    /// <returns></returns>
    public float GetMaxDEF()
    {
        return MaxDefence;
    }
    #endregion

    #region 敏捷度数值操作
    /// <summary>
    /// 更新敏捷度（典型应用场景：主角健康值改变；防御力改变；取得新武器）
    /// 公式：_MoveSpeed=MaxMoveSpeed+[道具敏捷力]
    /// </summary>
    /// <param name="newWeaponValues">新武器数值</param>
    public void UpdateDEXValues(float newWeaponValues = 0)
    {
        float reallyDEXValues = 0F;//实际的敏捷度数值

        if (newWeaponValues == 0)//没有获取新的武器道具
        {
            reallyDEXValues = MaxDexterity + DexterityByProp;
        }
        else if (newWeaponValues > 0)//取得武器道具
        {
            DexterityByProp = newWeaponValues;
            reallyDEXValues = MaxDexterity + DexterityByProp;
        }
        //数值有效性验证
        if (reallyDEXValues > MaxDexterity)
        {
            Dexterity = MaxDexterity;
        }
        else
        {
            Dexterity = reallyDEXValues;
        }
    }
    /// <summary>
    /// 得到当前敏捷度
    /// </summary>
    /// <returns></returns>
    public float GetCurrentDEX()
    {
        return Dexterity;
    }
    /// <summary>
    /// 增加最大敏捷度
    /// </summary>
    /// <param name="increaseDEX"></param>
    public void IncreaseMaxDEX(float increaseDEX)
    {
        MaxDexterity += Mathf.Abs(increaseDEX);
    }
    /// <summary>
    /// 得到最大敏捷度
    /// </summary>
    /// <returns></returns>
    public float GetMaxDEX()
    {
        return MaxDexterity;
    }
    #endregion
    #endregion

    #region 角色扩展属性

    public int Experience
    {
        get
        {
            return _IntEXP;
        }

        set
        {
            _IntEXP = value;
            //事件调用
            if (evePlayerData != null)
            {
                KeyValuesUpdate kv = new KeyValuesUpdate("Experience", Experience);
                evePlayerData(kv);
            }
        }
    }

    public int KillNumber
    {
        get
        {
            return _IntKillNum;
        }

        set
        {
            _IntKillNum = value;
            //事件调用
            if (evePlayerData != null)
            {
                KeyValuesUpdate kv = new KeyValuesUpdate("KillNumber", KillNumber);
                evePlayerData(kv);
            }
        }
    }

    public int Level
    {
        get
        {
            return _IntLevel;
        }

        set
        {
            _IntLevel = value;
            //事件调用
            if (evePlayerData != null)
            {
                KeyValuesUpdate kv = new KeyValuesUpdate("Level", Level);
                evePlayerData(kv);
            }
        }
    }

    public int Gold
    {
        get
        {
            return _IntGold;
        }

        set
        {
            _IntGold = value;
            //事件调用
            if (evePlayerData != null)
            {
                KeyValuesUpdate kv = new KeyValuesUpdate("Gold", Gold);
                evePlayerData(kv);
            }
        }
    }

    public int Diamonds
    {
        get
        {
            return _IntDiamonds;
        }

        set
        {
            _IntDiamonds = value;
            //事件调用
            if (evePlayerData != null)
            {
                KeyValuesUpdate kv = new KeyValuesUpdate("Diamonds", Diamonds);
                evePlayerData(kv);
            }
        }
    }
    #endregion
    #region 角色扩展属性策略
    #region 经验值
    /// <summary>
    /// 增加经验值
    /// </summary>
    /// <param name="addExp">经验数值</param>
    public void AddExp(int addExp)
    {
        Experience += Mathf.Abs(addExp);
        //经验值到达一定阶段 升级 
        UpgradeCondition(Experience);
    }
    /// <summary>
    /// 得到经验值
    /// </summary>
    /// <returns></returns>
    public int GetExp()
    {
        return Experience;
    }
    #endregion

    #region 杀敌数量
    /// <summary>
    /// 增加杀敌数量
    /// </summary>
    public void AddKillNumber()
    {
        ++KillNumber;
    }
    /// <summary>
    /// 得到杀敌数量
    /// </summary>
    /// <returns></returns>
    public int GetKillNumber()
    {
        return KillNumber;
    }
    #endregion

    #region 等级
    /// <summary>
    /// 增加等级
    /// </summary>
    public void AddLevel()
    {
        ++Level;
        //等级提升，属性提升
        UpgradeControl((LevelName)Level);
    }
    /// <summary>
    /// 得到等级
    /// </summary>
    /// <returns></returns>
    public int GetLevel()
    {
        return Level;
    }
    #endregion

    #region 金币
    /// <summary>
    /// 增加金币
    /// </summary>
    /// <param name="goldNumber"></param>
    public void AddGold(int goldNumber)
    {
        Gold += Mathf.Abs(goldNumber);
    }
    /// <summary>
    /// 得到金币
    /// </summary>
    /// <returns></returns>
    public int GetGold()
    {
        return Gold;
    }
    #endregion

    #region 钻石
    /// <summary>
    /// 增加钻石
    /// </summary>
    public void AddDiamonds(int diamondNumber)
    {
        Diamonds += Mathf.Abs(diamondNumber);
    }
    /// <summary>
    /// 得到钻石
    /// </summary>
    /// <returns></returns>
    public int GetDiamonds()
    {
        return Diamonds;
    }
    #endregion
    #endregion

    #region 升级操作
    /// <summary>
    /// 升级条件
    /// </summary>
    public void UpgradeCondition(int exp)
    {
        int currentLevel = 0;
        currentLevel = GetLevel();

        if (exp >= 100 && exp < 300 && currentLevel == 0)
        {
            AddLevel();
        }
        else if (exp >= 300 && exp < 500 && currentLevel == 1)
        {
            AddLevel();
        }
        else if (exp >= 500 && exp < 1000 && currentLevel == 2)
        {
            AddLevel();
        }
        else if (exp >= 1000 && exp < 3000 && currentLevel == 3)
        {
            AddLevel();
        }
        else if (exp >= 3000 && exp < 5000 && currentLevel == 4)
        {
            AddLevel();
        }
        else if (exp >= 5000 && exp < 10000 && currentLevel == 5)
        {
            AddLevel();
        }
    }

    /// <summary>
    /// 升级操作
    /// 1.处理核心最大数值增加
    /// 2.对应的核心数值，加满为最大数值
    /// </summary>
    public void UpgradeControl(LevelName lvName)
    {
        switch (lvName)
        {
            case LevelName.Level_0:
                UpgradeRuleControl(10, 10, 2, 1, 10);
                break;
            case LevelName.Level_1:
                UpgradeRuleControl(10, 10, 2, 1, 10);
                break;
            case LevelName.Level_2:
                UpgradeRuleControl(10, 10, 2, 1, 10);
                break;
            case LevelName.Level_3:
                UpgradeRuleControl(10, 10, 2, 1, 10);
                break;
            case LevelName.Level_4:
                UpgradeRuleControl(10, 10, 2, 1, 10);
                break;
            case LevelName.Level_5:
                UpgradeRuleControl(10, 10, 2, 1, 10);
                break;
            case LevelName.Level_6:
                UpgradeRuleControl(10, 10, 2, 1, 10);
                break;
            case LevelName.Level_7:
                UpgradeRuleControl(10, 10, 2, 1, 10);
                break;
            case LevelName.Level_8:
                UpgradeRuleControl(10, 10, 2, 1, 10);
                break;
            case LevelName.Level_9:
                UpgradeRuleControl(10, 10, 2, 1, 10);
                break;
            case LevelName.Level_10:
                UpgradeRuleControl(10, 10, 2, 1, 10);
                break;
            default:
                break;
        }
    }
    /// <summary>
    /// 具体的升级规则
    /// </summary>
    /// <param name="maxhp">最大生命值增量</param>
    /// <param name="maxmp">最大魔法值增量</param>
    /// <param name="maxATK">最大攻击力增量</param>
    /// <param name="maxDEF">最大防御力增量</param>
    /// <param name="maxDEX">最大敏捷度增量</param>
    public void UpgradeRuleControl(float maxhp, float maxmp, float maxATK, float maxDEF, float maxDEX)
    {
        //处理核心最大数值增加
        IncreaseMaxHealth(maxhp);
        IncreaseMaxMagic(maxmp);
        IncreaseMaxATK(maxATK);
        IncreaseMaxDEF(maxDEF);
        IncreaseMaxDEX(maxDEX);

        //hp mp加满为最大数值
        IncreaseHealthValues(GetMaxHealth());
        IncreaseMagicValues(GetMaxMagic());
    }
    #endregion
}
