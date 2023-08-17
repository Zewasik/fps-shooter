using System.Collections.Generic;
using UnityEngine;

public class PlayerGuns : MonoBehaviour
{
    public GameObject gunSlot;
    public GameObject player;
    private GameObject currentItem;
    private readonly List<GameObject> gunStorage = new();
    private PlayerUI playerUI;
    private bool isShooting = false;
    private int? currentSlotIndex;
    private Camera cam;

    private void Start()
    {
        playerUI = GetComponent<PlayerUI>();
        cam = GetComponentInChildren<Camera>();
    }

    public void StartShoot()
    {
        isShooting = true;
    }

    public void EndShoot()
    {
        isShooting = false;
    }

    public void TryAddGun(GameObject gunToCheck)
    {
        if (gunStorage.Count >= playerUI.inventorySlots.Count) return;
        if (currentItem) currentItem.SetActive(false);

        gunToCheck.layer = 0;
        gunToCheck.transform.parent = gunSlot.transform;
        gunToCheck.transform.SetPositionAndRotation(gunSlot.transform.position, gunSlot.transform.rotation);
        currentItem = gunToCheck;

        gunStorage.Add(gunToCheck);
        currentSlotIndex = gunStorage.Count - 1;
        playerUI.inventorySlots[currentSlotIndex.Value].sprite = gunToCheck.GetComponent<GunItem>().GetIcon();
    }

    public void TryReload()
    {
        if (currentItem != null && currentItem.TryGetComponent<GunItem>(out var currentGun))
            currentGun.StartReload();
    }

    private void TryUpdateAmmoCoutn()
    {
        if (currentItem != null && currentItem.TryGetComponent<GunItem>(out var currentGun))
            playerUI.UpdateAmmo(currentGun.GetAmmoCount());
    }
    public void TrySwitchGun(Vector2 scroll)
    {
        if (currentSlotIndex == null) return;

        int resultSlotIndex = currentSlotIndex.Value + (scroll.y > 0 ? 1 : scroll.y < 0 ? -1 : 0);
        if (resultSlotIndex >= 0 && resultSlotIndex < gunStorage.Count)
        {
            currentSlotIndex = resultSlotIndex;

            currentItem.SetActive(false);
            currentItem = gunStorage[currentSlotIndex.Value];
            currentItem.SetActive(true);
        }
    }


    private void Update()
    {
        if (isShooting && currentItem != null && currentItem.TryGetComponent<GunItem>(out var currentGun))
            currentGun.Shoot(cam.transform);
        TryUpdateAmmoCoutn();
    }
}
