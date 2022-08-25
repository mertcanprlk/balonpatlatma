using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalonOlusturucu : MonoBehaviour
{
    public GameObject balon;
    float BalonOlusturmaSuresi = 1f;
    float ZamanSayaci = 0f;
    OyunKontrol okScripti;
    // Start is called before the first frame update
    void Start()
    {
        okScripti = this.gameObject.GetComponent<OyunKontrol>();
    }

    // Update is called once per frame
    void Update()
    {
        ZamanSayaci -= Time.deltaTime;
        int katsayi = (int)(okScripti.zamanSayaci / 10) - 6;
        katsayi *= -1;
        if (ZamanSayaci < 0 && okScripti.zamanSayaci > 0)
        {
            GameObject go = Instantiate(balon, new Vector3(Random.Range(-1.9f, 1.9f), -7.5f, 0), Quaternion.Euler(0, 0, 0)) as GameObject;
            go.GetComponent<Rigidbody2D>().AddForce(new Vector3(0, Random.Range(150f * katsayi, 175f * katsayi), 0));
            ZamanSayaci = BalonOlusturmaSuresi;
        }
    }
}
