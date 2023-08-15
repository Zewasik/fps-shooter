using System.Collections;
using UnityEngine;

public class GunItem : MonoBehaviour
{
    public GameObject player;
    [SerializeField] GunData gunData;
    float timeSinceLastShot;
    Camera cam;

    public void PickUpGun()
    {
        player.GetComponent<PlayerGuns>().TryAddGun(transform.gameObject);
    }

    private bool CanShoot() => !gunData.reloading && timeSinceLastShot > 1f / (gunData.fireRate / 60f);

    public void Shoot()
    {
        if (gunData.currentAmmo <= 0) return;
        if (!CanShoot()) return;

        if (Physics.Raycast(cam.transform.position, cam.transform.forward, out RaycastHit camHitInfo, gunData.maxDistance, player.layer))
        {
            Vector3 dir = Vector3.Normalize(camHitInfo.point - transform.position);
            if (Physics.Raycast(transform.position, dir*gunData.maxDistance, out RaycastHit hitInfo, gunData.maxDistance))
            {
                if (hitInfo.transform.TryGetComponent<IDamageable>(out var damageable))
                {
                    damageable.Damage(gunData.damage);
                }
            }
        }

        gunData.currentAmmo--;
        timeSinceLastShot = 0;
        OnGunShot();
    }

    private void OnGunShot()
    {

    }

    public void StartReload()
    {
        if (!gunData.reloading)
        {
            StartCoroutine(Reload());
        }
    }

    private IEnumerator Reload()
    {
        gunData.reloading = true;

        yield return new WaitForSeconds(gunData.reloadTime);

        gunData.currentAmmo = gunData.magSize;
        gunData.reloading = false;
    }

    public int GetAmmoCount()
    {
        return gunData.currentAmmo;
    }

    public Sprite GetIcon()
    {
        return gunData.gunIcon;
    }

    void Start()
    {
        cam = player.GetComponentInChildren<Camera>();
    }

    void Update()
    {
        timeSinceLastShot += Time.deltaTime;
    }
}
