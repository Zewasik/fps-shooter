using UnityEngine;

public class GunData : MonoBehaviour
{
    [Header("Info")]
    public new string name;
    public Sprite gunIcon;

    [Header("Shooting")]
    public float damage;
    public float maxDistance;

    [Header("Reloading")]
    public int currentAmmo;
    public int magSize;
    public float fireRate;
    public float reloadTime;
    [HideInInspector]
    public bool reloading;
}
