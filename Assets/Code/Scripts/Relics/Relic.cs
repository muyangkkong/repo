using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu]
public class Relic : ScriptableObject
{
    public string RelicName;
    public string Rarity;
    public Sprite RelicImage;
    public float MaxHealthChanges;
    public float DamageChanges;
    public float ComboDamageChanges;
    public float RhythmSpeedChanges; //콤보 게이지의 이동 속도
    public float RhythmJudgeChanges;
    public float MoneyCollectChanges;
    public float SkillObtainChanges; // 스킬 게이지 획득량
    public float FirstAttackDamageChanges;
    public float SecondAttackDamageChanges;
    public float ThirdAttackDamageChanges;
    public float FourthAttackDamageChanges;
}
