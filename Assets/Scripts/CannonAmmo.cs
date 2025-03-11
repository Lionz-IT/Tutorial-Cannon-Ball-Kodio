using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CannonAmmo : MonoBehaviour
{
    public TextMeshProUGUI ammoText;
    public int totalAmmo;
    public int currentAmmo;
    public int CurrentAmmo
    {
        get
        {
            return currentAmmo;
        }
        set
        {
            currentAmmo = value;
            ammoText.text = "Ammo: " + currentAmmo + "/" + totalAmmo;
            print("Current Ammo: " +  currentAmmo);
            if (currentAmmo <= 0 && GameManager.Instance.fallenBrickAmount < GameManager.Instance.fallenBrickNeeded)
            {
                GameManager.level = 1;
                print("You Lose");
                GameManager.Instance.RestartGame();
            }
        }
    }
    private void Start()
    {
        GameManager.Instance.setAmmo += SetAmmo;
    }

    private void OnDisable()
    {
        GameManager.Instance.setAmmo -= SetAmmo;
    }

    private void SetAmmo()
    {
        totalAmmo = GameManager.Instance.fallenBrickNeeded / 3;
        currentAmmo = totalAmmo;
        ammoText.text = "Ammo: " + currentAmmo + "/" + totalAmmo;
    }
}
