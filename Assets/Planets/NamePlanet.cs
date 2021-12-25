using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NamePlanet : MonoBehaviour
{
    Names names;

    void Awake()
    {
        Rename();

    }

    private void Rename()
    {
        int index = (int)Random.Range((float)Names.Moon, (float)Names.Carme);
        Names nam = (Names)index;
        string name = nam.ToString();

        this.name = name;
    }
}
