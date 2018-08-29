using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class setDrop : MonoBehaviour
{

    public Dropdown year;
    public Dropdown month;
    public Dropdown day;


    void Awake()
    {
        inputYear();
        InputMonth();
        InputDay();
    }

    private void InputDay()
    {
        List<string> days = new List<string>();

        for (int i = 1; i < 32; i++)
        {
            days.Add(i.ToString());
        }
        day.AddOptions(days);
    }

    private void InputMonth()
    {
        List<string> months = new List<string>();

        for (int i = 1; i < 13; i++)
        {
            months.Add(i.ToString());

        }
        month.AddOptions(months);
    }

    void inputYear()
    {

        List<string> years = new List<string>();

        for (int i = 1955; i < 2019; i++)
        {
            years.Add(i.ToString());

        }
        year.AddOptions(years);
    }

}
