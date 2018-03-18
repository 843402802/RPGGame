using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Global;
public class EnemyAnimationEvent : MonoBehaviour {

    private EnemyAnimation _EnemyAnimation;
    private AudioSource _AudioSource;

    public AudioClip _AttackClip;

    private void Start()
    {
        _EnemyAnimation = GetComponentInParent<EnemyAnimation>();
        _AudioSource = GetComponent<AudioSource>();
    }

    public void AttackAnimationEvent()
    {
        _EnemyAnimation.AttackHeroByAnimationEvent();
        _AudioSource.clip = _AttackClip;
        _AudioSource.Play();
    }

}
