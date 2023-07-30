using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Rito.Demo
{
    public class Test_WRandomPick1 : MonoBehaviour
    {
        string a;
        
        public List<string> relics_random;
       
        
        
        
        public void Test()
        {
            var wrPicker = new Rito.WeightedRandomPicker<string>();

            // 아이템 및 가중치 목록 전달
            wrPicker.Add(

                

                ("note(특수)바이올린1", 80),
                ("note(특수)바이올린2", 80),
                ("note(특수)바이올린3", 80),
                ("note(특수)하프1", 80),
                ("note(특수)하프2", 80),
                ("note(특수)하프3", 80),
                ("note(특수)피아노1", 80),
                ("note(특수)피아노2", 80),//
                ("note(특수)피아노3", 80),
                ("note(특수)트럼펫1", 80),
                ("note(특수)트럼펫2", 80),
                ("note(특수)트럼펫3", 80),

                

                ("note(희귀)트럼펫", 20),
                ("note(희귀)하프", 20),
                ("note(희귀)피아노", 20),
                ("note(희귀)바이올린", 20)
            );

           
            
                
                
                while (relics_random.Count<2){
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