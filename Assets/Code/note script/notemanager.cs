using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class notemanager : MonoBehaviour
{
    public int bpm = 0;
    double currentTime =0d;

    [SerializeField]Transform tfNoteAppear = null;
    [SerializeField]GameObject goNote= null;

    timemanager theTimingManager;
    // Start is called before the first frame update
    void Start()
    {
        theTimingManager=GetComponent<timemanager>();
    }

    // Update is called once per frame
    void Update()
    {
        currentTime+=Time.deltaTime;

        if(currentTime>=80d/bpm)
        {
            GameObject t_note=Instantiate(goNote,tfNoteAppear.position,Quaternion.identity);
            theTimingManager.boxNoteList.Add(t_note);
            t_note.transform.SetParent(this.transform);
            currentTime-= 80d / bpm;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.CompareTag("Note"))
        {
            theTimingManager.boxNoteList.Remove(collision.gameObject);
            Destroy(collision.gameObject);
        }
    }
}
