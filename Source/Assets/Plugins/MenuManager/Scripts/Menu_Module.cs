using UnityEngine;
using System.Collections;
using System;
using UnityEngine.SceneManagement;

public class Menu_Module : MonoBehaviour
{
    //Load Default Menu
    public bool LoadDefaultMenu = false;
    public bool FadeBackground = false;
    //Menu Game Objects
    public GameObject[] Menu_List;
    public static GameObject CurrentMenu_Handler;
    // Use this for initialization
    void Start()
    {
        if (LoadDefaultMenu)
        {
            //Create main menu
            if(Menu_List.Length > 0 )
            OpenMenu(Menu_List[0].name);
        }

    }

    // Update is called once per frame
    void Update()
    {

    }

    //Scene Management Functions
    public void LoadScene(string Name)
    {


        //Start Scene
        try
        {
            SceneManager.LoadScene(Name);
        }
        catch (Exception ex)
        {
            Debug.Log("Error : " + ex.Message + " Unable to load scene");
        }
    }

    //Application Management Funcitons
    public void ExitApplication()
    {
       Application.Quit();
    }

    //Menu Management Function
    public void OpenMenu(string Name)
    {


        //Find Menu in menu list
        foreach (GameObject menu in Menu_List)
        {
            if (menu.name == Name)
            {
                //Close Previous Menu
                CloseMenu();

                //Show new menu

                CurrentMenu_Handler = Instantiate(menu, menu.transform.position, this.transform.localRotation) as GameObject;
                CurrentMenu_Handler.transform.SetParent(GameObject.Find("Menu-Manager").transform, false);
            }

        }
    }

    public void CloseMenu()
    {

        if (CurrentMenu_Handler != null)
        {

            Destroy(CurrentMenu_Handler);
        }


    }
}
