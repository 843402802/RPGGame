using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 作为各个控制脚本的中介者
/// </summary>
public class Hero : MonoBehaviour {

    private CharacterController _CharacterController;
    private Animation _Animation;
    private HeroAnimationControl _HeroAnimationControl;
    private HeroMovingControl _HeroMovingControl;
    private HeroAttackControl _HeroAttackControl;
    private PlayerInputControl _PlayerInputControl;
    private HeroProperty _HeroProperty;


    public CharacterController CharacterController
    {
        get
        {
            return _CharacterController;
        }
    }

    public Animation Animation
    {
        get
        {
            return _Animation;
        }
    }

    public HeroAnimationControl HeroAnimationControl
    {
        get
        {
            return _HeroAnimationControl;
        }
    }

    public HeroMovingControl HeroMovingControl
    {
        get
        {
            return _HeroMovingControl;
        }
    }

    public PlayerInputControl PlayerInputControl
    {
        get
        {
            return PlayerInputControl;
        }

    }

    public HeroAttackControl HeroAttackControl
    {
        get
        {
            return _HeroAttackControl;
        }
    }

    public HeroProperty HeroProperty
    {
        get
        {
            return _HeroProperty;
        }
    }

    void Start () {

        _Animation = GetComponentInChildren<Animation>();
        _CharacterController = GetComponent<CharacterController>();
        _HeroAnimationControl = GetComponent<HeroAnimationControl>();
        _HeroMovingControl = GetComponent<HeroMovingControl>();
        _HeroAttackControl = GetComponent<HeroAttackControl>();
        _PlayerInputControl = GetComponent<PlayerInputControl>();
        _HeroProperty = GetComponent<HeroProperty>();
    }

}
