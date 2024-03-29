using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UseMonkDiary4 : MonoBehaviour
{
    public static UseMonkDiary4 instance;

    #region 싱글톤
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
    #endregion

    private bool activated;
    private bool Gprevent;

    public GameObject diary4;
    public GameObject[] ob = new GameObject[4];

    public int[] answer = new int[4] { 1, 4, 2, 3 };
    private int[] Useranswer = new int[4] { 0, 0, 0, 0 };

    private int[] choosed = new int[4] {9, 9, 9, 9};    //0이면 이미 선택했던것
    private int cur = 0;
    private int curanswerNum = 0;

    public GameObject[] inactiveObjects;
    public GameObject[] activeObjects;



    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        
        activated = false;
        cur = 0;
        curanswerNum = 0;
        for (int i = 0; i < Useranswer.Length; i++)
        {
            Useranswer[i] = 0;
        }
        for (int i = 0; i < choosed.Length; i++)
        {
            choosed[i] = 9;
        }
        for (int i = 0; i < ob.Length; i++)
        {
            ob[i].SetActive(true);
        }
        diary4.SetActive(false);

        Gprevent = false;

    }

    // Update is called once per frame
    void Update()
    {
        if (activated)
        {
            if (Gprevent)
            {

                diary4.gameObject.SetActive(true);

                if (Input.GetKeyDown(KeyCode.RightArrow))
                {
                    for (int i = cur + 1; i < 4; i++)
                    {
                        if (choosed[i] != 0)
                        {
                            cur = i;
                            break;
                        }
                    }
                }
                else if (Input.GetKeyDown(KeyCode.LeftArrow))
                {
                    for (int i = cur - 1; i >= 0; i--)
                    {
                        if (choosed[i] != 0)
                        {
                            cur = i;
                            break;
                        }
                    }
                }
                else if (Input.GetKeyDown(KeyCode.G) || Input.GetKeyDown(KeyCode.Return))
                {
                    if (choosed[cur] == 0)
                    {
                        Debug.LogError("없어야하는 선택지다.");
                    }
                    else
                    {
                        choosed[cur] = 0;
                        ob[cur].gameObject.SetActive(false);
                        Useranswer[curanswerNum] = cur + 1;
                        curanswerNum++;

                    }
                    for (int i = 0; i < 4; i++)
                    {
                        if (choosed[i] != 0)
                        {
                            cur = i;
                            break;
                        }
                    }
                }
                else
                {

                }
                selectedIcon();

                //4번까지 모두 선택했을 시
                if (curanswerNum == 4)
                {
                    Debug.Log("끝난건지아닌건지");
                    checkAnswer();
                    ResetDiary4();
                    Inventory.instance.SetpreventExec2(true);
                    Gprevent = false;
                }
            }

            if (Input.GetKeyUp(KeyCode.G))
            {
                Gprevent = true;
            }

        }
        
    }
    private void selectedIcon()
    {
        Color color = ob[cur].gameObject.GetComponent<SpriteRenderer>().color;
        color.b = 1f;
        for(int i = 0; i < ob.Length; i++)
        {
            ob[i].GetComponent<SpriteRenderer>().color = color;
        }
        color.b = 0.8f;
        ob[cur].GetComponent<SpriteRenderer>().color = color;
    }
    private void checkAnswer()
    {
        for(int i = 0; i < 4; i++)
        {
            if(Useranswer[i] != answer[i])
            {
                SeveralDialogue.instance.Failure();
                return;
            }
        }

        Inventory.instance.GetAnItem(Constants.real_monkdiary4_ID);
        Inventory.instance.RemoveAnItem(Constants.previous_monkdiary4_ID);
        StoryFlow.instance.ActiveChildMemo8();
        StoryFlow.instance.ActiveEndingPoint();
        Inventory.instance.setActivated(false);
        SeveralDialogue.instance.AfterGetDiary4();
        GameObjectActive goba = new GameObjectActive();
        goba.InactiveObjects(inactiveObjects);
        goba.ActiveObjects(activeObjects);
    }
    private void ResetDiary4()
    {
        for (int i = 0; i < ob.Length; i++)
        {
            ob[i].gameObject.SetActive(true);
        }
        cur = 0;
        curanswerNum = 0;
        diary4.SetActive(false);
        activated = false;
        Inventory.instance.itemSetactive(true);
        for (int i = 0; i < Useranswer.Length; i++)
        {
            Useranswer[i] = 0;
        }
        for (int i = 0; i < choosed.Length; i++)
        {
            choosed[i] = 9;
        }
        
    }
    public void activeMonkDiary4(int _itemID)
    {
        Debug.Log("diary41");
        if(_itemID == Constants.previous_monkdiary4_ID)
            activated = true;
    }
}
