using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RelicCollect : MonoBehaviour
{
    ShopItem Base;

    private GameObject gameObject;
    private RelicInfo relicInfo;
    private int Cost;

    [SerializeField] Relic relic;

    private RelicArea relicArea;

    Vector3 position;
    public static int cost; 
    // Start is called before the first frame update
    void Start()
    {
        relicArea=GameObject.Find("ItemArea").GetComponent<RelicArea>();
        relicInfo=GameObject.Find("ItemText").GetComponent<RelicInfo>();     
        Base=GameObject.Find("Canvas").transform.GetComponent<ShopItem>();
        cost = RelicCost();
    }



    private void OnTriggerEnter(Collider col) {
        if (col.gameObject.tag=="Player"){     
            Vector3 position = this.transform.position; 
            relicInfo.ShowInfo(relic.Info, cost);
        }
    }

    private void OnTriggerStay(Collider col){

        if (col.gameObject.tag=="Player" && Input.GetKeyDown(KeyCode.C)){
            if (Base.total_coin<=Cost) {
                Base.total_coin-=Cost;
                gameObject.SetActive(false);
                }
            }
        }

    private void OnTriggerExit() {
        relicInfo.CloseInfo();
    }

    private int RelicCost(){
        if (relic.Rarity=="Common"){
            return 70 + Random.Range(0,21);
        }
        else if (relic.Rarity == "Unique"){
            return 150 + Random.Range(0,31);
        }
        else {
            return 0;
        }
    }
}

