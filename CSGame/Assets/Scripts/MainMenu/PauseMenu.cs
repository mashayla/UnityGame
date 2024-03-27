using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PauseMenu : MonoBehaviour
{
    public GameObject setting;
    public bool isSettingActive;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!isSettingActive == false)
            {
                Pause();
            }
            else
            {
                Resume();
            }
        }
    }

    public void Pause()
    {
        setting.SetActive(true);
        isSettingActive = true;

        //this.GetComponent<FirstPersonController>().GetComponent<MouseLook>().enabled = false;
        Cursor.lockState = CursorLockMode.None;
    }

    public void Resume()
    {
        setting.SetActive(false);
        isSettingActive = false;

        //this.GetComponent<MouseLook>().enabled = true;
        enabled = true;
        Cursor.lockState = CursorLockMode.Locked;
    }
}
