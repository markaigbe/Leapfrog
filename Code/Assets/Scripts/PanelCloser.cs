using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelCloser : MonoBehaviour
{
    public GameObject panelScreen;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ClosePanel()
    {
        if (panelScreen != null)
        {
            panelScreen.SetActive(false);
        }
    }
}
