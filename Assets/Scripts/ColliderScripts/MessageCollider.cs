using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MessageCollider : MonoBehaviour
{   
    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D collision)
    {
        SeveralDialogue.instance.CannotEnter();
    }
}
