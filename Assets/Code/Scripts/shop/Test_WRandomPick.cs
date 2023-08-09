using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Rito.Demo
{
    public class Test_WRandomPick : MonoBehaviour
    {
        string a;
        
        public List<string> relics_random;
       
        
        
        
        public void Test()
        {
            var wrPicker = new Rito.WeightedRandomPicker<string>();

            // 아이템 및 가중치 목록 전달
            wrPicker.Add(

                

                ("Beer", 80),
                ("Blue_potion", 80),//일반유물 
                ("Heart", 80),
                ("Money_bag", 80),
                

                ("4clover", 20),
                ("100_Score", 20),
                ("Clock",20)
            );

           
            
                
                
                while (relics_random.Count<3){
                    a=wrPicker.GetRandomPick();
                    
                    if(!relics_random.Contains(a)){
                    relics_random.Add(a);
                    }
                    else{
                        continue;
                    }
                    
                }
                
                

            
            
        }
    }
}