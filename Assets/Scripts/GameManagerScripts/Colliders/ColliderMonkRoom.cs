using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderMonkRoom :MonoBehaviour
{
    public string mapname = "MonkRoom";
    public static ColliderMonkRoom instance;
    #region �̱���
    private void Awake()    //�̱���!!
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

    public void transferMapEvent(string name)
    {
        if(name == mapname)
        {
            this.gameObject.SetActive(true);
        }
        else
        {
            this.gameObject.SetActive(false);
        }
    }
}
