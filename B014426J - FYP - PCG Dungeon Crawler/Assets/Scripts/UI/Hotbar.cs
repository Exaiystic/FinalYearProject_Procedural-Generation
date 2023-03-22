using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Hotbar : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] private GameObject spriteHolder;

    private Image image;

    private void Awake()
    {
        if (spriteHolder == null)
        { spriteHolder = gameObject.transform.Find("Sprite").gameObject; }

        if (image == null)
        { image = spriteHolder.GetComponent<Image>(); }
    }

    public void WeaponPickedUp(Sprite sprite)
    {
        spriteHolder.SetActive(true);
        image.sprite = sprite;
    }

    public void WeaponDropped()
    {
        spriteHolder.SetActive(false);
    }
}
