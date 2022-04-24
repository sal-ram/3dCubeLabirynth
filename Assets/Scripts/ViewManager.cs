using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ViewManager : MonoBehaviour
{
    public GameObject MainMenu;
    public GameObject FinishWindow;
    public GameObject MainMenuButton;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void FinishWindowActivate()
    {
        FinishWindow.SetActive(true);
        MainMenuButton.SetActive(false);
    }
}
