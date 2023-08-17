using System.Collections;
using UnityEngine;

public class GunItem : MonoBehaviour
{
    public GameObject player;
    [SerializeField] GunData gunData;
    float timeSinceLastShot = float.MaxValue;
    public GameObject particles;
    public GameObject muzzle;

    public void PickUpGun()
    {
        player.GetComponent<PlayerGuns>().TryAddGun(transform.gameObject);
    }

    private bool CanShoot() => !gunData.reloading && timeSinceLastShot > 1f / (gunData.fireRate / 60f);

    public void Shoot(Transform from)
    {
        if (gunData.currentAmmo <= 0) return;
        if (!CanShoot()) return;

        if (Physics.Raycast(from.position, from.forward, out RaycastHit camHitInfo, gunData.maxDistance))
        {
            if (camHitInfo.transform.TryGetComponent<IDamageable>(out var damageable))
            {
                damageable.Damage(gunData.damage);
            }
        }

        gunData.currentAmmo--;
        timeSinceLastShot = 0;
        OnGunShot();
    }

    private void OnGunShot()
    {
        var newParticles = Instantiate(particles, muzzle.transform);
        newParticles.SetActive(true);
        Destroy(newParticles, 0.1f);
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

    public float GetMaxDistance()
    {
        return gunData.maxDistance;
    }

    public Sprite GetIcon()
    {
        return gunData.gunIcon;
    }

    void Start()
    {
        particles.SetActive(false);
    }

    void Update()
    {
        timeSinceLastShot += Time.deltaTime;
    }
}
