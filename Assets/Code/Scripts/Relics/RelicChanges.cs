using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RelicChanges : MonoBehaviour
{
    public RelicArea relicArea;
    public float RelicMaxHealth;
    public float RelicDamage;
    public float RelicComboDamage;
    public float RelicRhythmSpeed; //콤보 게이지의 이동 속도
    public float RelicRhythmJudge;
    public float RelicMoneyCollect;
    public float RelicSkillObtain; // 스킬 게이지 획득량
    public float RelicFirstAttackDamage;
    public float RelicSecondAttackDamage;
    public float RelicThirdAttackDamage;
    public float RelicFourthAttackDamage;



    private void Awake() {
        relicArea = GetComponent<RelicArea>();
        reset();
    }
    
    public void reset() {
        RelicMaxHealth = 1f;
        RelicDamage = 1f;
        RelicComboDamage = 1f;
        RelicRhythmSpeed = 1f;
        RelicRhythmJudge = 1f;
        RelicMoneyCollect = 1f;
        RelicSkillObtain = 1f;
        RelicFirstAttackDamage = 1f;
        RelicSecondAttackDamage = 1f;
        RelicThirdAttackDamage = 1f;
        RelicFourthAttackDamage = 1f;
    }

    public void RelicStatus() {
        reset();
        for (int i=0 ; i<relicArea.relics.Count;i++) {
            Relic TempRelic = relicArea.relicslot[i].relic;

            RelicMaxHealth += TempRelic.MaxHealthChanges;
            
            RelicDamage += TempRelic.DamageChanges;
            RelicComboDamage += TempRelic.ComboDamageChanges;
            
            RelicRhythmSpeed += TempRelic.RhythmSpeedChanges;
            RelicRhythmJudge += TempRelic.RhythmJudgeChanges;
            
            RelicMoneyCollect += TempRelic.MoneyCollectChanges;
            RelicSkillObtain += TempRelic.SkillObtainChanges;

            RelicFirstAttackDamage += TempRelic.FirstAttackDamageChanges;
            RelicSecondAttackDamage += TempRelic.SecondAttackDamageChanges;
            RelicThirdAttackDamage += TempRelic.ThirdAttackDamageChanges;
            RelicFirstAttackDamage += TempRelic.FourthAttackDamageChanges;
        }
    }

}