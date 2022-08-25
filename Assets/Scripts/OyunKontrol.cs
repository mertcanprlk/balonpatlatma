using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OyunKontrol : MonoBehaviour
{
    public UnityEngine.UI.Text zamanText, balonText, durum;
    public float zamanSayaci = 60;
    public GameObject patlama;
    float patlayanBalon = 0;
    public UnityEngine.UI.Button btn;
    bool oyunDevam = true;
    bool bölümTamam = false;
    // Start is called before the first frame update
    void Start()
    {
        balonText.text = "balon : " + patlayanBalon;
    }

    // Update is called once per frame
    void Update()
    {
        if (zamanSayaci > 0)
        {
            zamanSayaci -= Time.deltaTime;
            zamanText.text = "süre : " + (int)zamanSayaci;
        }
        else
        {
            GameObject[] go = GameObject.FindGameObjectsWithTag("balon");
            for (int i = 0; i < go.Length; i++)
            {
                Instantiate(patlama, go[i].transform.position, go[i].transform.rotation);
            }
        }
        if (oyunDevam && !bölümTamam)
        {
            zamanSayaci -= Time.deltaTime; //zamansayaci = zamansayaci-time.deltatime
            zamanText.text = "süre : " + (int)zamanSayaci;

        }
        else if (!bölümTamam)
        {
            durum.text = "Oyun Bitti";
            btn.gameObject.SetActive(true);
        }
        if (zamanSayaci < 0)
            oyunDevam = false;
    }
    public void Balonekle()
    {
        patlayanBalon += 1;
        balonText.text = "balon : " + patlayanBalon;
    }
}