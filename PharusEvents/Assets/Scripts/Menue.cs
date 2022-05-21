using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menue : MonoBehaviour
{
    public string MenueName;
    public bool open;
    public void Open()
    {
        open = true;
        gameObject.SetActive(true);
    }

    public void Close()
    {
        open = false;
        gameObject.SetActive(false);
    }
}
