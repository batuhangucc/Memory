using UnityEngine;

public class AmmoDisplay : MonoBehaviour
{
    public GameObject ammoIconPrefab; 
    public Transform ammoContainer; 
    public int maxAmmo; 
    private GameObject[] ammoIcons;

    void Start()
    {
        ammoIcons = new GameObject[maxAmmo];
        for (int i = 0; i < maxAmmo; i++)
        {
            ammoIcons[i] = Instantiate(ammoIconPrefab, ammoContainer);
        }
        UpdateAmmoDisplay(maxAmmo);
    }

    public void UseAmmo()
    {
        if (maxAmmo > 0)
        {
            maxAmmo--;
            UpdateAmmoDisplay(maxAmmo);
        }
    }

    private void UpdateAmmoDisplay(int currentAmmo)
    {
        for (int i = 0; i < ammoIcons.Length; i++)
        {
            ammoIcons[i].SetActive(i < currentAmmo);
        }
    }
}
