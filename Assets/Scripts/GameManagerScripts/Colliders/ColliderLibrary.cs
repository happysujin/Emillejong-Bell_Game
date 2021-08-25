using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderLibrary : MonoBehaviour
{
    public string mapname = "library";
    public static ColliderLibrary instance;
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
        if (name == mapname)
        {
            this.transform.GetChild(0).gameObject.SetActive(true);
        }
        else
        {
            this.transform.GetChild(0).gameObject.SetActive(false);
        }
    }
}
