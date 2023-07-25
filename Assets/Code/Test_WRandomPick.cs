using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Rito.Demo
{
    public class Test_WRandomPick : MonoBehaviour
    {
        string a;
        public bool _flag;
        public List<string> relics_random;
        private void OnValidate()
        {
            if (_flag)
            {
                _flag = false;
                Test();
            }
        }

        void Test()
        {
            var wrPicker = new Rito.WeightedRandomPicker<string>();

            // 아이템 및 가중치 목록 전달
            wrPicker.Add(

                

                ("Beer", 80),
                ("Blue_potion", 80),//일반유물 
                ("Heart", 80),
                ("Money_bag", 80),
                

                ("4clover", 20),
                ("100_score", 20),
                ("Clock",20)
            );

           
            for (int i=0;i<3;i++){
                a=wrPicker.GetRandomPick();
                for (int j =0;j<relics_random.Count;j++){
                    if (relics_random[j]!=a){
                        relics_random.Add(a);
                    }
                Debug.Log(relics_random);
                }
                

            }
                
                

            
            
            

            
        }
    }
}