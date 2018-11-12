using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectMenu : MonoBehaviour {

    [SerializeField] Selectable[] defaultBtn;
    [SerializeField] GameObject[] panels;

    public void PanelToggle(int index)
    {
        Input.ResetInputAxes();
        for(int i=0;i<panels.Length;i++)
        {
            panels[i].SetActive(i == index);
            if (i == index)
                defaultBtn[i].Select();
        }

    }

	// Use this for initialization
	void Start () {
        PanelToggle(0);
	}
	
}
