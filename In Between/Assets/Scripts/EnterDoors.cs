using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EnterDoors : MonoBehaviour
{
    bool r1;
    bool r2;
    bool r3;
    bool r4;

    public GameObject enterRoom1Text;

    private void Update()
    {
        
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("d1"))
        {
            enterRoom1Text.SetActive(true);

            if (Input.GetKeyDown(KeyCode.L))
            {
                SceneManager.LoadScene("Room1");
            }
        }
        if (other.gameObject.CompareTag("d2"))
        {
            enterRoom1Text.SetActive(true);

            if (Input.GetKeyDown(KeyCode.L))
            {
                SceneManager.LoadScene("Room2");
            }
        }
        if (other.gameObject.CompareTag("d3"))
        {
            enterRoom1Text.SetActive(true);

            if (Input.GetKeyDown(KeyCode.L))
            {
                SceneManager.LoadScene("Room3");
            }
        }
        if (other.gameObject.CompareTag("d4"))
        {
            enterRoom1Text.SetActive(true);

            if (Input.GetKeyDown(KeyCode.L))
            {
                SceneManager.LoadScene("Room4");
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("d1") || other.gameObject.CompareTag("d2") || other.gameObject.CompareTag("d3") || other.gameObject.CompareTag("d4"))
        {
            enterRoom1Text.SetActive(false);
        }
    }
}
