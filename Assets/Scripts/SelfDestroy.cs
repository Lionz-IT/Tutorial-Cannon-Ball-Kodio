using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfDestroy : MonoBehaviour
{
    public int destroyTimer;
    private void Start()
    {
        Destroy(gameObject, destroyTimer);
    }
}
