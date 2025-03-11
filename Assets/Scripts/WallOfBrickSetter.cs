using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallOfBrickSetter : MonoBehaviour
{
    private void Start()
    {
        GameManager.Instance.fallenBrickNeeded += transform.childCount;
        GameManager.Instance.SetAmmo();
    }
}
