using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyController : MonoBehaviour
{
    float keys;

    public GameObject keyText;

    public Animator keyAnims;

    private void Start()
    {
        keys = 0;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("key"))
        {
            other.gameObject.SetActive(false);
            AudioController.play2 = true;
            keys++;
            keyText.SetActive(true);

            StartCoroutine(keyWait());
        }
    }

    IEnumerator keyWait()
    {
        yield return new WaitForSeconds(2f);
        keyAnims.SetTrigger("keyExit");
        yield return new WaitForSeconds(0.25f);
        keyText.SetActive(false);
    }
}
