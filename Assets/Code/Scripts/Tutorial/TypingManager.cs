using System.Collections;

using UnityEngine;
using UnityEngine.UI;


public class TypingManager : MonoBehaviour
{
    public Text m_TypingText;
    public string m_Message;
    public float m_Speed;
    
    // Start is called before the first frame update
    void Start()
    {
        
        StartCoroutine(_typing());
    }
    IEnumerator _typing(){
        Debug.Log("start");
        for (int i=0;i<=m_Message.Length;i++){
            m_TypingText.text=m_Message.Substring(0,i);
            yield return new WaitForSeconds(m_Speed);
        }
        

    }
    // Update is called once per frame
    
}
