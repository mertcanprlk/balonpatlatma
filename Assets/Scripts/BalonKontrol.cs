using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalonKontrol : MonoBehaviour
{
    public GameObject patlama;
    OyunKontrol oyunkontrolscripti;
    public AudioClip patlamases;
    private void Start()
    {
        oyunkontrolscripti = GameObject.Find("Scripts").GetComponent<OyunKontrol>();
    }
    void OnMouseDown()
    {
        GameObject go = Instantiate(patlama, transform.position, transform.rotation) as GameObject;
        Destroy(this.gameObject);
        Destroy(go, 1.683f);
        oyunkontrolscripti.Balonekle();
        GetComponent<AudioSource>().PlayOneShot(patlamases, 1f);
        }
    void OnCollisionEnter(Collision c)
    {
        if (c.gameObject.tag.Equals("balon"))
        {
            oyunkontrolscripti.Balonekle();
            Destroy(c.gameObject);
            GetComponent<AudioSource>().PlayOneShot(patlamases, 1f);
        }
    }
    }