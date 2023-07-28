using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStat : MonoBehaviour
{
    RelicChanges relicChange;
    PlayerAttack playerattack;
    CharacterHP characterHP;
    TimingBarManager timingBarManager;
    PlayerEquipment playerEquipment;

    private float PlayerBasicDamage = 20f;
    private float PlayerBasicMaxHealth = 100f;
    private float RhythmBasicSpeed = 3f;
    private float RhythmBasicJudge = 0.2f;
    private float BasicComboDamage = 1f;
    private float BasicMoneyCollect =1f;
    private float BasicSkillObtain = 1f;

    private float BasicFirstAttackDamage = 1f;
    private float BasicSecondAttackDamage = 1f;
    private float BasicThirdAttackDamage = 1f;
    private float BasicFourthAttackDamage = 1f; 

    private float WeaponRhythmSpeed = 1f;
    private float WeaponFirstAttackDamage = 1f;
    private float WeaponSecondAttackDamage = 1f;
    private float WeaponThirdAttackDamage = 1f;
    private float WeaponFourthAttackDamage = 1f;

    private float _PlayerDamage = 10;
    public float PlayerDamage {
        get {return _PlayerDamage;}
        set {
            _PlayerDamage = value;
            playerattack.power = _PlayerDamage;
        }
    }


    public float ComboDamage;

    private float _MaxHp = 200;
    public float MaxHp {
        get {return _MaxHp;}
        set {
            _MaxHp = value;
            characterHP.maxHp = _MaxHp;}
    }

    private float _MaxAcceptInterval = 0.2f;
    public float MaxAcceptInterval {
        get {return _MaxAcceptInterval;}
        set {
            _MaxAcceptInterval = value;
            playerattack.maxAcceptInterval = _MaxAcceptInterval;
        }
    }

    private float _TimerSpeed = 3;
    public float TimerSpeed {
        get {return _TimerSpeed;}
        set {
            _TimerSpeed = value;
            timingBarManager.timerSpeed = _TimerSpeed;
        }
    }

    public float SkillObtain;
    public float MoneyCollect;


    private void Start(){
        relicChange = GameObject.Find("ItemArea").GetComponent<RelicChanges>();
        playerattack = GameObject.Find("Player").GetComponent<PlayerAttack>();
        characterHP = GameObject.Find("Player").GetComponent<CharacterHP>();
        timingBarManager = GameObject.Find("Timing Bar").GetComponent<TimingBarManager>();
        playerEquipment = GameObject.Find("Player").GetComponent<PlayerEquipment>();
    }
/*
    private void update() {
        StatApply();
        WeaponApply();
    }

    public void WeaponApply() 
    {
        if (playerEquipment.instrument.MType == "InstrumentHarp") {
            WeaponRhythmSpeed = 0.7f;
            WeaponThirdAttackDamage = 1.3f;
            WeaponFourthAttackDamage = 1.3f;     
        }
        else if (playerEquipment.instrument.MType == "InstrumentPiano") {
            WeaponRhythmSpeed = 1.3f;
            WeaponFirstAttackDamage = 1.3f;
            WeaponSecondAttackDamage = 1.3f;
        }
        else { 
            WeaponRhythmSpeed = 1f;
            WeaponFirstAttackDamage = 1f;
            WeaponSecondAttackDamage = 1f;
            WeaponThirdAttackDamage = 1f;
            WeaponFourthAttackDamage = 1f;
        } 
    }

    public void StatApply(){
        MaxHp = PlayerBasicMaxHealth * relicChange.RelicMaxHealth;
        
        PlayerDamage = PlayerBasicDamage * relicChange.RelicDamage;
        ComboDamage = BasicComboDamage * relicChange.RelicComboDamage;

        BasicFirstAttackDamage = relicChange.RelicFirstAttackDamage;
        BasicSecondAttackDamage = relicChange.RelicSecondAttackDamage;
        BasicThirdAttackDamage = relicChange.RelicThirdAttackDamage;
        BasicFourthAttackDamage = relicChange.RelicFourthAttackDamage;
                
        TimerSpeed = RhythmBasicSpeed * relicChange.RelicRhythmSpeed;
        MaxAcceptInterval = RhythmBasicJudge * relicChange.RelicRhythmSpeed;

        SkillObtain = BasicSkillObtain * relicChange.RelicSkillObtain;
        MoneyCollect = BasicMoneyCollect * relicChange.RelicMoneyCollect;
    }

    public float DamageCalculate(int ComboNumber, float ComboDamageValue)
    {
        float AttackValue = 1f;
        if (ComboNumber == 1) {AttackValue = AttackValue * BasicFirstAttackDamage * WeaponFirstAttackDamage;}
        if (ComboNumber == 2) {AttackValue = AttackValue * BasicSecondAttackDamage * WeaponSecondAttackDamage;}
        if (ComboNumber == 3) {AttackValue = AttackValue * BasicThirdAttackDamage * WeaponThirdAttackDamage;}
        if (ComboNumber == 4) {AttackValue = AttackValue * BasicFourthAttackDamage * WeaponFourthAttackDamage;}
        
        
        return PlayerDamage * AttackValue * ComboDamageValue;

    }*/
}
