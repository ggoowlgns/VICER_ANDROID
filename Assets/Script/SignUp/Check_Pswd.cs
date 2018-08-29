using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Check_Pswd : MonoBehaviour
{

    private string original_Text;
    private string check_Text;
    private bool isInput = false;

    public Text check_Result_Text;
    public Text original_pswd;
    public Text check_pswd;

    void Start()
    {
        check_Result_Text.GetComponent<Text>().text = "Enter pswd Again";
        
    }

    // Update is called once per frame
    void Update()
    {
        original_Text = original_pswd.GetComponent<Text>().text;
        check_Text = check_pswd.GetComponent<Text>().text;

        if (check_Text != "")
        {
            isInput = true;
        }

        if (check_Text == original_Text && isInput == true)
        {
            check_Result_Text.GetComponent<Text>().text = "Correct!";
        }
        else if (check_Text != original_Text && isInput == true)
        {
            check_Result_Text.GetComponent<Text>().text = "Not Same... Check your pswd";
        }

    }
}
