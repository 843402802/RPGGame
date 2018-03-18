using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroAnimationEvent : MonoBehaviour {

    private AudioSource _AudioSource;
    private Hero _Hero;

    public AudioClip _NormalAttackClip;
    public AudioClip _MagicAttack_AClip;
    public AudioClip _MagicAttack_BClip;
	void Start () {
        _Hero = GetComponentInParent<Hero>();
        _AudioSource = GetComponent<AudioSource>();
    }

    public void AnimationEvent_NormalAttack()
    {
        PlayAudioClip(_NormalAttackClip);
        _Hero.HeroAttackControl.AttackEnemyByNormal();
    }
    public void AnimationEvent_HeroMagicA()
    {
        PlayAudioClip(_MagicAttack_AClip);
        _Hero.HeroAnimationControl.StartCoroutine("AnimationEvent_HeroMagicA");
        _Hero.HeroAttackControl.AttackEnemyByMagicA();
    }
    public void AnimationEvent_HeroMagicB()
    {
        PlayAudioClip(_MagicAttack_BClip);
        _Hero.HeroAnimationControl.StartCoroutine("AnimationEvent_HeroMagicB");
        _Hero.HeroAttackControl.AttackEnemyByMagicB();
    }


    private void PlayAudioClip(AudioClip clip)
    {
        _AudioSource.clip = clip;
        _AudioSource.Play();
    }


}
