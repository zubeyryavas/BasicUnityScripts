using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Text.RegularExpressions;

public class Menu : MonoBehaviour
{

    public InputField nickNameInput;
    public string nickName;

    public Text errorToggle;
    const string error_message = "Please check this box to play.";

    public Toggle checkbox;

    public void CheckError()
    {
        nickName = nickNameInput.text;
    
    }
    public void StartGame()
    {
        if (!checkbox.isOn)
        {
            errorToggle.text = error_message;
        }
        else
        {
            SceneManager.LoadScene("Unity04");
        }
    }
   
    public void ExitGame()
    {
        Application.Quit();
    }

  


}
