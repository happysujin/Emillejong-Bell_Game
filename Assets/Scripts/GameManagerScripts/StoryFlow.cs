using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoryFlow : MonoBehaviour
{
    public static StoryFlow instance;

    private void Awake()    //싱글톤!!
    {
        if (instance != null)
        {
            Destroy(this.gameObject);
            return;
        }
        else
        {
            DontDestroyOnLoad(this.gameObject);
            instance = this;
        }
    }
    //진짜 스님의 일기장1을 휙득 후 스님방에서 나갈 수 있음
    //스님의 진짜 일기장4를 휙득 후 동자승의 메모#8을 휙득할 수 있는 콜라이더 활성화됨
    //연못 다섯바퀴 돌아야 지하실 열쇠사용 가능 (지하실열쇠사용 콜라이더 활성화)
    //지하실 열쇠를 사용 후 지하실 입장 가능

    //아이템을 휙득하였는지는 Inventory.instance.FindItem(int _itemID) 함수로 찾을 수 있음 (return은 bool 형태)
    //연못 다섯바퀴 돌았는지는 Requirement.instance.getHalfKeyAble(); 로 검사 - 이거 휙득은 pond.cs에서
    //지하실 열쇠를 모두 썼는지는 Requirement.instance.IsBasementOpened();
    private bool CanGetOutOfMonkRoom = false;
    public GameObject ChildMemo8;
    public GameObject endingPoint;
    private bool CanGetIntoBasement = false;

    public GameObject[] PhysicColliders;
    public GameObject[] MessageColliders;
    
    public void GotRealMonkDiary1(bool _is)
    {
        CanGetOutOfMonkRoom = _is;
        if (CanGetOutOfMonkRoom)
        {
            for(int i = 0; i < PhysicColliders.Length; i++)
            {
                PhysicColliders[i].SetActive(false);
            }
            for (int i = 0; i < MessageColliders.Length; i++)
            {
                MessageColliders[i].SetActive(false);
            }
        }
    }

    public void ActiveChildMemo8()
    {
        ChildMemo8.SetActive(true);
    }
    public void ActiveEndingPoint()
    {
        endingPoint.SetActive(true);
    }

    public void SetCanGetIntoBasement(bool _is)
    {
        CanGetIntoBasement = _is;
        if (CanGetIntoBasement)
        {
            PondToBase.instance.OpenBasement();
            PondToBase.instance.OpenCollider();
        }
    }






    // Start is called before the first frame update
    void Start()
    {
        ChildMemo8.SetActive(false);
        endingPoint.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (!CanGetOutOfMonkRoom)
        {
            //스님방에서 나갈 수 없음 또는 스님방만 들어갈 수 있음?   //이것도 어디파일인진 모르겠는데 스님방만 들어갈 수 있게 함
        }
        if (CanGetIntoBasement)
        {
            //지하실 들어갈 수 있음 //pondtobasement 파일에서 막는 콜라이더 없애고 지하실로 가는  tranfermap 초가해줌
        }
    }
}
