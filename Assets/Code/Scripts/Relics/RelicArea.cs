using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RelicArea : MonoBehaviour
{
    public List<Relic> relics;
    public RelicChanges relicChanges;

    [SerializeField] Transform slotParent;
    [SerializeField] RelicSlot[] slots;
    public RelicSlot[] relicslot {get{return slots;}}

    private void OnValidate() {
        slots=slotParent.GetComponentsInChildren<RelicSlot>();  
    }

    void Awake() {
        relicChanges = GetComponent<RelicChanges>();
        FreshSlot();
    }

    public void FreshSlot() {
        int i = 0;
        for (; i < relics.Count && i < slots.Length; i++) {
            slots[i].relic= relics[i];
        }
        for (; i < slots.Length; i++) {
            slots[i].relic = null;
        }
        relicChanges.RelicStatus();
    }

    public void AddRelic(Relic relic)
    {
        if (relics.Count < slots.Length) {
            relics.Add(relic);
            FreshSlot();
        }
        else
        {
            Debug.Log("가득 참");
        }
    }
}
