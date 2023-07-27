using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour
{
    public GameObject[] back;
    GameObject[] clone;
    // Start is called before the first frame update
    private static Background instance = null;

    public AudioClip backgroundMusicA;
    public AudioClip backgroundMusicB;
    public AudioClip backgroundMusicC;
    public AudioClip backgroundMusicD;
    public AudioClip backgroundMusicE;
    public AudioClip backgroundMusicF;

    public AudioSource audioSource;

    void Awake()
    {
        if (null == instance)
        {
            //�� Ŭ���� �ν��Ͻ��� ź������ �� �������� instance�� ���ӸŴ��� �ν��Ͻ��� ������� �ʴٸ�, �ڽ��� �־��ش�.
            instance = this;

            //�� ��ȯ�� �Ǵ��� �ı����� �ʰ� �Ѵ�.
            //gameObject�����ε� �� ��ũ��Ʈ�� ������Ʈ�μ� �پ��ִ� Hierarchy���� ���ӿ�����Ʈ��� ��������, 
            //���� �򰥸� ������ ���� this�� �ٿ��ֱ⵵ �Ѵ�.
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            //���� �� �̵��� �Ǿ��µ� �� ������ Hierarchy�� GameMgr�� ������ ���� �ִ�.
            //�׷� ��쿣 ���� ������ ����ϴ� �ν��Ͻ��� ��� ������ִ� ��찡 ���� �� ����.
            //�׷��� �̹� ���������� instance�� �ν��Ͻ��� �����Ѵٸ� �ڽ�(���ο� ���� GameMgr)�� �������ش�.
            Destroy(this.gameObject);
        }
    }

    //���� �Ŵ��� �ν��Ͻ��� ������ �� �ִ� ������Ƽ. static�̹Ƿ� �ٸ� Ŭ�������� ���� ȣ���� �� �ִ�.
    public static Background Instance
    {
        get
        {
            if (null == instance)
            {
                return null;
            }
            return instance;
        }
    }

    void Start()
    {
         // AudioSource 컴포넌트 가져오기
        audioSource = GetComponent<AudioSource>();

        clone = new GameObject[back.Length];
        BuildBack(0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void BuildBack(int n)
    {
        GameObject buildBack = Instantiate(back[n], transform.position, Quaternion.identity,transform);
        clone[n] = buildBack;

        audioSource.volume=1f;

         audioSource.Stop();

        if (n == 0)
        {
            // 배경 음악 A를 재생
            audioSource.clip = backgroundMusicA;
            Debug.Log("n="+n);
        }
        else if (n == 1)
        {
            // 배경 음악 B를 재생
            audioSource.clip = backgroundMusicB;
            audioSource.volume=0.3f;
            Debug.Log("n="+n);
        }
         else if (n == 2)
        {
            // 배경 음악 B를 재생
            audioSource.clip = backgroundMusicC;
            Debug.Log("n="+n);
        }
         else if (n == 6)
        {
            // 배경 음악 B를 재생
            audioSource.clip = backgroundMusicD;
            audioSource.volume=0.3f;
            Debug.Log("n="+n);
        }
         else if (n == 3)
        {
            // 배경 음악 B를 재생
            audioSource.clip = backgroundMusicE;
            audioSource.volume=0.6f;
        }
         else if (n == 4)
        {
            // 배경 음악 B를 재생
            audioSource.clip = backgroundMusicF;
        }

        audioSource.loop=true;

         audioSource.Play();

    }
    public void DestroyBack()

    {
        for(int n=0;n<clone.Length; n++)
            if (clone[n]!=null)
                Destroy(clone[n]);
    }
}
