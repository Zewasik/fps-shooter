using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class PlayerUI : MonoBehaviour
{
    public List<Image> inventorySlots = new List<Image>();
    [SerializeField]
    private TextMeshProUGUI promptMessage;
    [SerializeField]
    private TextMeshProUGUI ammoCount;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void UpdateText(string promptMessage)
    {
        this.promptMessage.text = promptMessage;
    }

    public void UpdateAmmo(int newAmmoCount)
    {
        this.ammoCount.text = newAmmoCount.ToString();
    }
}
