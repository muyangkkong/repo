using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RelicChanges : MonoBehaviour
{
    public RelicArea relicArea;
    public TimingBarManager timingBarManager;
    public float RelicMaxHealth;
    public float RelicDamage;
    public float RelicComboDamage;
    public float RelicNonComboDamage;
    public float RelicRhythmSpeed; //콤보 게이지의 이동 속도
    public float RelicRhythmJudge;
    public float RelicMoneyCollect;
    public float RelicSkillObtain; // 스킬 게이지 획득량




    private void Awake() {
        relicArea = GetComponent<RelicArea>();
        reset();
    }
    
    public void reset() {
        RelicMaxHealth = 1f;
        RelicDamage = 1f;
        RelicComboDamage = 1f;
        RelicNonComboDamage = 1f;
        RelicRhythmSpeed = 1f;
        RelicRhythmJudge = 1f;
        RelicMoneyCollect = 1f;
        RelicSkillObtain = 1f;
    }

    public void RelicStatus() {
        reset();
        for (int i=0 ; i<relicArea.relics.Count;i++) {
            Relic TempRelic = relicArea.relicslot[i].relic;

            RelicMaxHealth += TempRelic.MaxHealthChanges;
            RelicDamage += TempRelic.DamageChanges;
            RelicComboDamage += TempRelic.ComboDamageChanges;
            RelicNonComboDamage += TempRelic.NonComboDamageChanges;
            RelicRhythmSpeed += TempRelic.RhythmSpeedChanges;
            RelicRhythmJudge += TempRelic.RhythmJudgeChanges;
            RelicMoneyCollect += TempRelic.MoneyCollectChanges;
            RelicSkillObtain += TempRelic.SkillObtainChanges;
        }
    }

}
