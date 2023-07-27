using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Instrument : MonoBehaviour
{
    protected string InstrumentType;
    public string MType {get {return InstrumentType;}}

    protected ComboDictionary comboDictionary = new ComboDictionary();
    protected int rootId;
    protected int currentAttackId;
    protected int attackDepth;
    protected int currentComboLength;

    public GameObject leftArmed = null;
    public GameObject rightArmed = null;

    public AnimationClip[] animationClips;

    public abstract void Construct();
    public abstract void Init();
    
    public ComboData AttackProgress(int timing, int type) {
        if(GetCurrentAttackData().children[timing,type] == 0) return null;
        currentAttackId = GetCurrentAttackData().children[timing,type];
        attackDepth += 1;
        currentComboLength += timing;
        return GetCurrentAttackData();
    }

    public ComboData GetCurrentAttackData() {
        return comboDictionary.GetComboData(currentAttackId);
    }
    public void InitProgress() {
        currentAttackId = rootId;
        attackDepth = 0;
        currentComboLength = 0;
    }

    public void ParseCSV(string csvName) {
        int[,] children;

        List<Dictionary<string,object>> Combo = CSVReader.Read("Violin_Combo");
        for (int i=0; i < Combo.Count; i++)
        {
            children = new int[5,2];
            children[0,0] = (int)Combo[i]["0A"];
            children[1,0] = (int)Combo[i]["1A"];
            children[2,0] = (int)Combo[i]["2A"];
            children[3,0] = (int)Combo[i]["3A"];
            children[4,0] = (int)Combo[i]["4A"];

            children[0,1] = (int)Combo[i]["0B"];
            children[1,1] = (int)Combo[i]["1B"];
            children[2,1] = (int)Combo[i]["2B"];
            children[3,1] = (int)Combo[i]["3B"];
            children[3,1] = (int)Combo[i]["4B"];          

            comboDictionary.SetComboData((int)Combo[i]["ID"],(string)Combo[i]["Name"], 0 , children);
        }
        rootId = (int)Combo[0]["ID"];
    }

    public float GetGuageMultiplier() {
        return currentComboLength;
    }
}

//시작 공격 : 모든 콤보를 시작하는 공격. 이전 공격이 없기 때문에 딜레이 역시 없어 A,B 두 가지 공격으로 정의됨
//연계 공격 : 이전의 공격으로부터 연계되는 공격. 1~4까지의 정수 딜레이와 A, B 두 가지 공격 총 8가지 공격으로 정의됨
//콤보 : 하나의 시작 공격과 0개 이상의 연계 공격의 조합을 의미함
//완성 콤보 : 콤보 중에서도 충분한 갯수의 연계 공격이 포함된 콤보로, 마지막 연계 공격 이후 딜레이 카운팅이 종료되는 콤보
//구현해야 할 것 : 몇가지 콤보를 공통으로 갖는 5개의 완성 콤보