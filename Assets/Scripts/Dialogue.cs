using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Dialogue
{
    //Will host information about our dialogue
    public string name;

    //we can edit the size of the text box of the  inspector
    [TextArea(3,10)]
    public string[] sentences;
    //Se criarmos um script que pode ser editado no inspector ptemos que colocar Serializable
}
