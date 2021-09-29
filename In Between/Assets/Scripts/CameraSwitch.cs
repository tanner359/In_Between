using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSwitch : MonoBehaviour
{
    public static bool inContact1;
    public static bool inContact2;

    public GameObject cam1;
    public GameObject cam1Far;
    public GameObject cam2;
    public GameObject cam2Far;

    private void Start()
    {
        inContact1 = false;
        inContact2 = false;
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (SwitchCharacters.ghostNum == 1)
            {
                inContact1 = true;

                cam1Far.SetActive(true);
                cam1.SetActive(false);
            }
            if (SwitchCharacters.ghostNum == 0)
            {
                inContact2 = true;

                cam2Far.SetActive(true);
                cam2.SetActive(false);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (SwitchCharacters.ghostNum == 1)
            {
                inContact1 = false;

                cam1.SetActive(true);
                cam1Far.SetActive(false);
            }
            if (SwitchCharacters.ghostNum == 0)
            {
                inContact2 = false;

                cam2.SetActive(true);
                cam2Far.SetActive(false);
            }
        }
    }
}
