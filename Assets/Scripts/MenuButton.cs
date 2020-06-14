
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class MenuButton : MonoBehaviour, IPointerClickHandler
{
   

    public string _action;

    public void OnPointerClick(PointerEventData eventData)
    {
        MenuEvent(_action);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            MenuEvent(_action);
        }
    }

    private void MenuEvent(string a)
    {
       if(a == "play")
        {
            SceneManager.LoadScene("Level1");
        }
       if(a == "exit")
        {
            Application.Quit();
        }
    }
}
