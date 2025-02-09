using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Portals : MonoBehaviour
{
    private GameObject partner;
    [SerializeField] private float cooldown = 3.0f;
    [SerializeField] private GameObject[] ignoreList;
    private void Awake()
    {
        if (transform.GetSiblingIndex() == 0)
        {
            partner = transform.parent.transform.GetChild(transform.GetSiblingIndex() + 1).gameObject;
        }
        else
        {
            partner = transform.parent.transform.GetChild(transform.GetSiblingIndex() - 1).gameObject;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        bool teleport = true;
        for (int i = 0; i < ignoreList.Length; i++)
        {
            if (collision.gameObject == ignoreList[i])
            {
                teleport = false;
            }
        }
        if (teleport)
        {
            collision.gameObject.transform.position = new Vector2(partner.transform.position.x, partner.transform.position.y);
            GetComponent<CapsuleCollider2D>().enabled = false;
            partner.GetComponent<CapsuleCollider2D>().enabled = false;
            GetComponent<SpriteRenderer>().color = new Color(GetComponent<SpriteRenderer>().color.r, GetComponent<SpriteRenderer>().color.g, GetComponent<SpriteRenderer>().color.b, 0.5f);
            partner.GetComponent<SpriteRenderer>().color = new Color(partner.GetComponent<SpriteRenderer>().color.r, partner.GetComponent<SpriteRenderer>().color.g, partner.GetComponent<SpriteRenderer>().color.b, 0.5f);
            transform.GetChild(0).gameObject.SetActive(false);
            partner.transform.GetChild(0).gameObject.SetActive(false);
            GetComponent<AudioSource>().Play();
            StartCoroutine(Cooldown());
        }
    }
    IEnumerator Cooldown()
    {
        yield return new WaitForSecondsRealtime(cooldown);
        GetComponent<CapsuleCollider2D>().enabled = true;
        partner.GetComponent<CapsuleCollider2D>().enabled = true;
        GetComponent<SpriteRenderer>().color = new Color(GetComponent<SpriteRenderer>().color.r, GetComponent<SpriteRenderer>().color.g, GetComponent<SpriteRenderer>().color.b, 1.0f);
        partner.GetComponent<SpriteRenderer>().color = new Color(partner.GetComponent<SpriteRenderer>().color.r, partner.GetComponent<SpriteRenderer>().color.g, partner.GetComponent<SpriteRenderer>().color.b, 1.0f);
        transform.GetChild(0).gameObject.SetActive(true);
        partner.transform.GetChild(0).gameObject.SetActive(true);
    }
}
